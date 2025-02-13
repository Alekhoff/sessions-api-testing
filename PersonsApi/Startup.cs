using Core.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PersonsApi.Services;

namespace PersonsApi;

public class Startup: IModuleStartup
{
    public void ConfigureServices(IServiceCollection pServices, IConfiguration pConfiguration)
    {
        pServices.AddScoped<PersonService>();
    }
}