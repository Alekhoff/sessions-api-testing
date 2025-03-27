using System.Net.Http.Json;
using StarWars.Models;

namespace StarWars.Services.External;

public class SwapiHttpClient(HttpClient httpClient)
{
    internal async IAsyncEnumerable<T> GetAllDataFromEndpointAsync<T>(string pEndpoint, CancellationToken ct)
    {
        var vUrl = $"{pEndpoint}?page=1";

        while (!string.IsNullOrEmpty(vUrl))
        {
            var response = await httpClient.GetFromJsonAsync<SwapiResponseModel<T>>(vUrl, ct);

            if (response?.Results != null)
            {
                foreach (var person in response.Results)
                {
                    yield return person;
                }
            }

            vUrl = !string.IsNullOrEmpty(response?.Next) ? ExtractNextPageUrl(pEndpoint, response.Next) : null;
        }
    }
    public async Task<T?> FetchResourceAsync<T>(string pResourceUrl, CancellationToken ct)
    {
        try
        {
            return await httpClient.GetFromJsonAsync<T>(pResourceUrl, ct);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching resource from {pResourceUrl}: {ex.Message}");
            return default;
        }
    }

    
    private static string ExtractNextPageUrl(string pEndpoint, string pNextUrl)
    {
        var uri = new Uri(pNextUrl);
        var queryParams = System.Web.HttpUtility.ParseQueryString(uri.Query);
        var page = queryParams["page"];

        return !string.IsNullOrEmpty(page) ? $"{pEndpoint}?page={page}" : string.Empty;
    }

}