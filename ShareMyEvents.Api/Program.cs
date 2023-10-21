using Microsoft.EntityFrameworkCore;
using ShareMyEvents.Api.Data;

namespace ShareMyEvent.Api;

public class Program
{
    public static void Main (string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddDbContext<ShareMyEventsApiContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("ShareMyEventsApiContext") ?? throw new InvalidOperationException("Connection string 'ShareMyEventsApiContext' not found.")));

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if(app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
