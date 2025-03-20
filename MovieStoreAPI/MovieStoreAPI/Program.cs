using Microsoft.EntityFrameworkCore;
using MovieStoreAPI.Data;
using MovieStoreAPI.Endpoints;
using System.Threading.Tasks;

namespace MovieStoreAPI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Connectionstring setup
            builder.Services.AddDbContext<MovieContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("MovieDbCS")));

            var app = builder.Build();

            // Seed data into database
            using(var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<MovieContext>();
                    await context.Database.MigrateAsync();
                }
                catch(Exception ex)
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
