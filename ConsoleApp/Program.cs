using System.Net.Http.Json;
using System.Text.Json;
using ConsoleApp;
using ConsoleApp.Models;
using Microsoft.Extensions.DependencyInjection;

// var services = new ServiceCollection();
// services.RegisterServices();

var vList = new List<AilmentModel>();
await foreach (var vAilment in GetDataFromExtApi(CancellationToken.None))
{
    Console.WriteLine(vAilment?.Name);
    if(vAilment != null)
        vList.Add(vAilment);
}

var vIEnumerable = ConvertList(vList);

Console.WriteLine("Press any key to exit...");
Console.ReadKey();
return;



IEnumerable<AilmentModel?> ConvertList(List<AilmentModel> vList)
{
    foreach (var ailment in vList)
    {
        yield return ailment;
    }
}

IAsyncEnumerable<AilmentModel?> GetDataFromExtApi(CancellationToken ct)
{
    var client = new HttpClient();
    client.BaseAddress = new Uri("https://mhw-db.com/");
    var vUrl = new Uri("ailments", UriKind.Relative);
    
    return client.GetFromJsonAsAsyncEnumerable<AilmentModel>(vUrl, ct);
    
    // var response = await client.GetAsync(vUrl, ct);
    // var data = await response.Content.ReadAsStringAsync(ct);
    // var vJsonOptions = new JsonSerializerOptions()
    // {
    //     PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    // };
    //
    // var json = JsonSerializer.Deserialize<List<AilmentModel>>(data, vJsonOptions);
    //
    // // var res2 = await client.GetFromJsonAsync<List<AilmentModel>>(vUrl, ct);
    //
    //
    // foreach (var ailment in json)
    // {
    //     yield return ailment;
    // }
}

