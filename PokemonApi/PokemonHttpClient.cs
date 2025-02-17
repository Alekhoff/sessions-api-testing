using System.Net.Http.Json;

namespace PokemonApi;

public class PokemonHttpClient(HttpClient httpClient)
{
    internal async Task<T?> GetPokemonByNameAsync<T>(string pokemonName, CancellationToken ct = default)
    {
        var response = await httpClient.GetAsync($"pokemon/{pokemonName}", ct);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<T>(cancellationToken: ct);
    }
}