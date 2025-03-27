using CoreLibrary.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StarWars.Data;
using StarWars.Services;
using StarWars.Services.External;

namespace StarWars;

public class Startup : IModuleStartup
{
    public static void RegisterModule(IServiceCollection pServices, IConfiguration pConfiguration)
    {
        pServices.AddScoped<StarWarsService>();
        pServices.AddControllers()
            .AddApplicationPart(typeof(Startup).Assembly);
        pServices.AddDbContext<EfDbContext>(pOptions =>
        {
            pOptions.UseSqlServer("Server=localhost;Database=StarWars;User Id=sa;Password=YourStrong!Passw0rd;TrustServerCertificate=True;");
            pOptions.EnableSensitiveDataLogging();
            pOptions.EnableDetailedErrors();
        });
        pServices.AddHttpClient<SwapiHttpClient>(pClient =>
        {
            pClient.BaseAddress = new Uri("https://swapi.dev/api/");
            pClient.DefaultRequestHeaders.Add("User-Agent", "starwars-api");
        });

    }
}