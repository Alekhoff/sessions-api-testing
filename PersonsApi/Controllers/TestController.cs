using Microsoft.AspNetCore.Mvc;
using PersonsApi.Services;

namespace PersonsApi.Controllers;
[ApiController]
[Route("api/[controller]")]
public class TestController(PersonService service) : ControllerBase
{
    [HttpGet("Test")]
    public async Task<IActionResult> Test(CancellationToken ct)
    {
        var vPerson = await service.GetPerson("Aleksander", "Hoff");
        return Ok(vPerson);
    }
}