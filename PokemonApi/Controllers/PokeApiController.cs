using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using PokemonApi.Models;
using PokemonApi.Services;

namespace PokemonApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PokeApiController(PokemonService service, DataHandler sqlClient) : ControllerBase
{

    [HttpGet("Pokemon/{pokemonName}")]
    public async Task<IActionResult> GetPokemon(string pokemonName, CancellationToken ct)
    {
        var vResult = await service.GetPokemon<Pokemon>(pokemonName, ct);
        
        return Ok(vResult);
    }
    
    [HttpPost("Pokemon/{pokemonName}")]
    public async Task<IActionResult> StorePokemonToDb(string pokemonName, CancellationToken ct)
    {
        var vCommand = new SqlCommand("INSERT INTO atbl_aPokemon_Pokemon (Name, Height, Weight) VALUES (@Name, @Height, @Weight)");
        var vPokemon = await service.GetPokemon<Pokemon>(pokemonName, ct);
        vCommand.Parameters.AddWithValue("@Name", vPokemon.Name.ToUpper());
        vCommand.Parameters.AddWithValue("@Height", vPokemon.Height);
        vCommand.Parameters.AddWithValue("@Weight", vPokemon.Weight);
            
        var vResult = await sqlClient.PostDataAsync<Pokemon>(vCommand, ct);
        return Ok(vResult);
        
    }
}

