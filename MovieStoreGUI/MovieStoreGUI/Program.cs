using MovieStoreGUI.Clients;
using MovieStoreGUI.Components;

namespace MovieStoreGUI;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args); 

        // Add services to the container.
        builder.Services.AddRazorComponents().AddInteractiveServerComponents();

        // setup connectionstring
        //var movieAppUrl = builder.Configuration["movieApiUrl"] ?? throw new Exception("Movie API URL not set");
        var movieAppUrl = builder.Configuration.GetConnectionString("movieApiUrl") ?? throw new Exception("Movie API URL not set");

        // add HttpClient to app services.
        builder.Services.AddHttpClient<MoviesClient>(client => client.BaseAddress = new Uri(movieAppUrl));
        builder.Services.AddHttpClient<GenresClient>(client => client.BaseAddress = new Uri(movieAppUrl));

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection(); // redirects HTTP reguests to HTTPS

        app.UseStaticFiles(); // serves static files such as images, CSS, and Javascript in wwwroot folder
        app.UseAntiforgery(); // protects application from cross-site requeest forgery (CSRF) attacks

        // enable serverside rendering of components
        app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

        app.Run();
    }
}
