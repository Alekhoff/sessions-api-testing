using Microsoft.Extensions.DependencyInjection;

namespace ConsoleApp;

public static class DependecyInjection
{
    public static IServiceCollection RegisterServices(this IServiceCollection pServices)
    {
        pServices.AddScoped<TestService>();
        return pServices;
    }
}