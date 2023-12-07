using Microsoft.AspNetCore.Authentication.JwtBearer;
using ShareMyEvents.Api.Services;
using NSwag;
using NSwag.Generation.Processors.Security;
using System.Reflection;
using ShareMyEvents.Api.Configuration.OptionsSetup;
using ShareMyEvents.Api.Configuration.Authentication;
using ShareMyEvents.Domain.Interfaces;
using Jerkoder.Common.Domain.Jwt.Interfaces;
using Microsoft.Extensions.Options;
using Jerkoder.Common.Domain.Database;
using ShareMyEvents.Api.Database;
using Jerkoder.Common.Domain.Database.Interfaces;
using FluentValidation;
using MediatR;
using ShareMyEvents.Api.Behaviors;

namespace ShareMyEvents.Api.Configuration;
internal class Startup
{
    private static WebApplicationBuilder _builder;

    public static void Initialize (string[] args)
    {
        if (_builder == null)
        {
            _builder = WebApplication.CreateBuilder(args);
        }

        ConfigureServices ();
        Configure();
    }

    private static void ConfigureServices()
    {
        _builder?.Host.ConfigureServices((context, services) =>
        {
            services.AddControllers();

            // Options
            ConfigureOptions(services);

            // DbContext
            ConfigureDbContextService(services);

            // Repositories
            RegisterRepositories(services, Assembly.GetExecutingAssembly());

            // Authentication with JWT
            ConfigureAuthenticationService(services, context);

            // Swagger
            ConfigureSwaggerService(services);

            // MediatR
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly(), includeInternalTypes: true);

            RegisterDomainServices(services);
        });
    }

    private static void Configure ()
    {
        var app = _builder.Build();

        // Configure the HTTP request pipeline.
        if(app.Environment.IsDevelopment())
        {
            app.UseOpenApi();
            app.UseSwaggerUi();
            app.UseDeveloperExceptionPage();
        }

        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }

    private static void ConfigureDbContextService(IServiceCollection services)
    {
        services.AddDbContext<ShareMyEventsApiContext>((serviceProvider, dbContextOptions) =>
        {
            var databaseOptions = serviceProvider.GetService<IOptions<DatabaseSqlServerOptions>>()!.Value;

            dbContextOptions.UseSqlServer(databaseOptions.ConnectionString, sqlServerOptionsAction =>
            {
                sqlServerOptionsAction.EnableRetryOnFailure(databaseOptions.MaxRetryCount);
                sqlServerOptionsAction.CommandTimeout(databaseOptions.CommandTimeout);
            });

            dbContextOptions.EnableDetailedErrors(databaseOptions.EnableDetailedErrors);
            dbContextOptions.EnableSensitiveDataLogging(databaseOptions.EnableSensitiveDataLogging);
        });
    }

    private static void ConfigureOptions(IServiceCollection services)
    {
        services.ConfigureOptions<DatabaseOptionsSetup>();
        services.ConfigureOptions<JwtOptionsSetup>();
        services.ConfigureOptions<JwtBearerOptionsSetup>();
    }

    private static void ConfigureAuthenticationService(IServiceCollection services, HostBuilderContext context)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();
    }

    private static void ConfigureSwaggerService(IServiceCollection services)
    {
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();

        services.AddOpenApiDocument(options =>
        {
            options.PostProcess = document =>
            {
                document.Info = new OpenApiInfo
                {
                    Version = "v1",
                    Title = "ShareMyEvents Api"
                };
            };

            options.OperationProcessors.Add(new OperationSecurityScopeProcessor("JWT Token"));

            options.AddSecurity("JWT Token", new OpenApiSecurityScheme()
            {
                Name = "Authorization",
                Type = OpenApiSecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = OpenApiSecurityApiKeyLocation.Header,
                Description = "Enter Bearer [space] and then your valid token in the input text below"
            });
        });
    }

    private static void RegisterDomainServices(IServiceCollection services)
    {
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<IEventService, EventService>();
        services.AddScoped<IParticipationService, ParticipationService>();
        services.AddScoped<IJwtProvider<User>, JwtProvider>();
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        services.AddTransient<CancellationTokenSource, CancellationTokenSource>();
    }

    private static void RegisterRepositories (IServiceCollection services, Assembly assembly)
    {
        var repositoryTypes = assembly.GetTypes()
            .Where(type => !type.IsAbstract && !type.IsInterface && type.GetInterfaces().Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IBaseRepository<>)));

        // filter out RepositoryBase<>
        var nonBaseRepos = repositoryTypes.Where(t => t != typeof(IBaseRepository<>));

        foreach(var repositoryType in nonBaseRepos)
        {
            var interfaces = repositoryType.GetInterfaces()
                .Where(@interface => !@interface.IsGenericType)
                .ToList();

            if(interfaces.Count != 1)
            {
                throw new InvalidOperationException($"Repository '{repositoryType.Name}' must implement only one interface that implements IBaseRepository<>.");
            }

            services.AddTransient(interfaces[0], repositoryType);
        }
    }
}
