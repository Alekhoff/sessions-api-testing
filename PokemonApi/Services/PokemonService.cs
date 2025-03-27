using System.Net.Http.Json;
using PokemonApi.Models;

namespace PokemonApi.Services;

public class PokemonService (PokemonHttpClient pokeClient)
{
    public async Task<T> GetPokemon<T>(string pPokemonName, CancellationToken ct)
    {
        var vPokemon =  await pokeClient.GetPokemonByNameAsync<T>(pPokemonName, ct);
        return vPokemon ?? throw new Exception("Failed To Get Pokemon");
    }
    public async Task<T> GetPokemonGender<T>(int pId, CancellationToken ct)
    {
        var vPokemon =  await pokeClient.GetPokemonGenderAsync<T>(pId, ct);
        return vPokemon ?? throw new Exception("Failed To Get Pokemon");
    }
}