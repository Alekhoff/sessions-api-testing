using Microsoft.AspNetCore.Mvc;
using PokemonApi.Models;
using PokemonApi.Services;

namespace PokemonApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PokeApiController(PokemonService service) : ControllerBase
{
    [HttpGet("Pokemon/{pokemonName}")]
    public async Task<IActionResult> GetPokemon(string pokemonName, CancellationToken ct)
    {
        var vResult = await service.GetPokemon<Pokemon>(pokemonName, ct);
        
        return Ok(vResult);
    }
}