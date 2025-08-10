using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MovieAPI.Data;
using MovieAPI.Endpoints;

namespace MovieAPI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Use connection string from appsettings.json
            builder.Services.AddDbContext<MovieContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MovieDbCS")));

            var app = builder.Build();

            //Asynchronous method to seed data into out database
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<MovieContext>();
                    await context.Database.MigrateAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error has occured while migrating the database: {ex.Message}");
                }
            }

            app.MapGet("/", () => "Hello World!");
            app.MapMoviesEndpoints();
            app.MapGenresEndpoints();
            app.Run();
        }
    }
}
