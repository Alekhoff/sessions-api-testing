using CoreLibrary.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WeatherForecastApi;

public class Startup : IModuleStartup
{
    public static void RegisterModule(IServiceCollection pServices, IConfiguration pConfiguration)
    {
        // pServices.AddScoped<WeatherService>();
        pServices.AddControllers()
            .AddApplicationPart(typeof(Startup).Assembly);
    }
}