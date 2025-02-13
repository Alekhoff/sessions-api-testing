using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CoreLibrary.Interfaces;

public interface IModuleStartup
{
    static void RegisterModule(IServiceCollection pServices, IConfiguration pConfiguration){}

}