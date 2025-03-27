using Microsoft.AspNetCore.Mvc;
using StarWars.Services;

namespace StarWars.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StarWarsController(StarWarsService service) : ControllerBase
{

    [HttpGet("test")]
    public async Task<IActionResult> GetPokemon(CancellationToken ct)
    {
        var vResult = await service.GetAllPeople(ct);
    
        return Ok(vResult);
    }
}