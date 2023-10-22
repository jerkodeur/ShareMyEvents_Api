using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using ShareMyEvents.Api.Data;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;

namespace ShareMyEvents.Api.Configuration;
internal class Startup
{
    private static WebApplicationBuilder _builder;
    private static DbContext _smeDbContext;

    public static void Initialize (string[] args)
    {
        if (_builder == null)
        {
            _builder = WebApplication.CreateBuilder(args);
        }

        RegisterServices ();
        Configure();
    }

    private static void Configure ()
    {
        var app = _builder.Build();

        // Configure the HTTP request pipeline.
        if(app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }

    private static void RegisterServices()
    {
        _builder?.Host.ConfigureServices((context, services) =>
        {
            // DbContext
            RegisterDbContextService(services);

            services.AddControllers();

            // Swagger
            RegisterSwaggerService(services);

            // Authentication with JWT
            RegisterAuthenticationService(services, context);
        });
    }

    private static void RegisterDbContextService(IServiceCollection services)
    {
        services.AddDbContext<ShareMyEventsApiContext>(dbContextOptions =>
        {
            IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

            var connectionString = configuration.GetConnectionString("ShareMyEventsApiContext") ?? throw new InvalidOperationException("Connection string 'ShareMyEventsApiContext' not found.");
            dbContextOptions.UseSqlServer(connectionString);
        });
    }

    private static void RegisterAuthenticationService(IServiceCollection services, HostBuilderContext context)
    {
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            //options.SaveToken = true;
            options.TokenValidationParameters = new()
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(context.Configuration["Jwt:Secret"])),
                ValidIssuer = context.Configuration["Jwt:ValidIssuer"],
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };
        });
    }

    private static void RegisterSwaggerService(IServiceCollection services)
    {
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options =>
        {
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "Enter Bearer [space] and then your valid token in the input text below"
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] {}
                }
            });
        });
    }
}
