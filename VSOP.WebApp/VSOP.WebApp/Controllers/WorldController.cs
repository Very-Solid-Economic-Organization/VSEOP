using Microsoft.AspNetCore.Mvc;

namespace VSOP.WebApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WorldController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetWorlds()
    {
        return Ok();
    }
}