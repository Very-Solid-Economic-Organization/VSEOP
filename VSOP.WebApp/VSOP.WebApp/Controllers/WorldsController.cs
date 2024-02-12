using MediatR;
using Microsoft.AspNetCore.Mvc;
using VSOP.Application.Requests.Worlds.Commads.CreateWorld;
using VSOP.Contracts.Worlds;
using VSOP.Domain.DbModels.Worlds;
using VSOP.Domain.Primitives.Results;
using VSOP.WebApp.Abstractions;


namespace VSOP.WebApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WorldsController : ApiController
{

    public WorldsController(ISender sender) : base(sender)
    {  }

    [HttpGet]
    public async Task<IActionResult> GetWorlds()
    {
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateWorldRequest request)
    {
        Result<World> result = await Sender.Send(new CreateWorldCommand(request.Name));
       
        if (result.IsFailure)
            return HandleFailure(result); //TODO : раскидать ошибки

        return Ok(result.Value); //TODO: Изменить ответы с дб-ных моделий на другие (подумать)
    }
}