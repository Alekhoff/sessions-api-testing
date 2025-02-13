namespace Core.Interfaces;

public interface IModuleStartup
{
    void ConfigureServices(IServiceCollection pServices, IConfiguration pConfiguration);

}