using System.Net.Http.Json;

namespace PokemonApi;

public class PokemonHttpClient(HttpClient httpClient)
{
    internal async Task<T?> GetPokemonByNameAsync<T>(string pokemonName, CancellationToken ct)
    {
        var response = await httpClient.GetAsync($"pokemon/{pokemonName}", ct);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<T>(cancellationToken: ct);
    }
    
    internal async Task<T?> GetPokemonGenderAsync<T>(int pId, CancellationToken ct)
    {
        var response = await httpClient.GetAsync($"/gender/{pId}", ct);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<T>(cancellationToken: ct);
    }
    
    internal async Task<T?> GetPokemonGenderNewHttpAsync<T>(int pId, CancellationToken ct)
    {
        var vHttpClient = new HttpClient
        {
            BaseAddress = new Uri("https://pokeapi.co/api/v2/")
        };
        var vUrl = new Uri($"pokemon/{pId}", UriKind.Relative);
        var vRequest = new HttpRequestMessage(HttpMethod.Get, vUrl);
        
       var response = await vHttpClient.SendAsync(vRequest, ct);
       response.EnsureSuccessStatusCode();
       
       return await response.Content.ReadFromJsonAsync<T>(cancellationToken: ct);
    }
}