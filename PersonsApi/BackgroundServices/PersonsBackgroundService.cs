using Microsoft.Extensions.Hosting;

namespace PersonsApi.BackgroundServices;

public class PersonsBackgroundService : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken ct)
    {
        while (!ct.IsCancellationRequested)
        {
            Console.WriteLine("Background job for PersonsApi running...");
            await Task.Delay(10000, ct); 
        }
    }
}