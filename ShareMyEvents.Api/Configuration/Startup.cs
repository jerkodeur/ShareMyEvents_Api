using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using ShareMyEvents.Api.Data;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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

        app.UseAuthorization();
        app.UseAuthentication();

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
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

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
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(context.Configuration["Jwt:Secret"])),
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };

        });
    }
}
