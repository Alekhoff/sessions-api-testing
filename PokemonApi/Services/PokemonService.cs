using System.Net.Http.Json;
using PokemonApi.Models;

namespace PokemonApi.Services;

public class PokemonService (PokemonHttpClient pokeClient)
{
    public async Task<T> GetPokemon<T>(string pPokemonName, CancellationToken ct)
    {
        var vPokemon =  await pokeClient.GetPokemonByNameAsync<T>(pPokemonName, ct);
        return vPokemon ?? throw new Exception("Failed To Get POkemon");
    }
}