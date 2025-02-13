using CoreLibrary.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using PersonsApi.Actions;
using PersonsApi.BackgroundServices;
using PersonsApi.Services;

namespace PersonsApi;

public class Startup: IModuleStartup
{
    public static void RegisterModule(IServiceCollection pServices, IConfiguration pConfiguration)
    {
        pServices.AddHealthChecks()
            .AddCheck("DatabaseConnectionCheck", () =>
            {
                // Simulate some database connection check
                const bool dbIsHealthy = true;
                return dbIsHealthy ? HealthCheckResult.Healthy("Database is fine.") : HealthCheckResult.Unhealthy("Database is not reachable.");
            });

        
        pServices.AddScoped<PersonService>();
        pServices.AddHostedService<PersonsBackgroundService>();
        pServices.AddControllers(pOptions =>
        {
            pOptions.Filters.Add<LogActionFilter>();
        }).AddApplicationPart(typeof(Startup).Assembly);


        //
        // pServices.AddControllers()
        //     .AddApplicationPart(typeof(Startup).Assembly);
    }
}