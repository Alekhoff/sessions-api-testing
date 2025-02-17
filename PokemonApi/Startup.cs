using CoreLibrary.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PokemonApi.Services;

namespace PokemonApi;

public class Startup : IModuleStartup
{
    public static void RegisterModule(IServiceCollection pServices, IConfiguration pConfiguration)
    {
        pServices.AddScoped<PokemonService>();
        pServices.AddHttpClient<PokemonHttpClient>(pClient =>
        {
            pClient.BaseAddress = new Uri("https://pokeapi.co/api/v2/");
            pClient.DefaultRequestHeaders.Add("User-Agent", "PokemonApi");
            
        });
        pServices.AddControllers()
            .AddApplicationPart(typeof(Startup).Assembly);
    }
}