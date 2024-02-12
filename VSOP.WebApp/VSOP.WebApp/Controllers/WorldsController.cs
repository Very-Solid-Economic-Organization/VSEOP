using MediatR;
using Microsoft.AspNetCore.Mvc;
using VSOP.Application.Requests.Worlds.Commads.CreateWorld;
using VSOP.Application.Requests.Worlds.Commads.RemoveWorld;
using VSOP.Application.Requests.Worlds.Queries.GetWorldById;
using VSOP.Application.Requests.Worlds.Queries.GetWorldList;
using VSOP.Contracts.Worlds;
using VSOP.Domain.DbModels.Worlds;
using VSOP.Domain.Primitives.Results;
using VSOP.WebApp.Abstractions;

namespace VSOP.WebApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WorldsController : ApiController //TODO: уйти от дб-шных моделей
{

    public WorldsController(ISender sender) : base(sender)
    { }

    [HttpGet]
    public async Task<IActionResult> GetWorlds()
    {
        Result<List<World>> result = await Sender.Send(new GetWorldListQuery());
        if (result.IsFailure)
            return HandleFailure(result);

        return Ok(result.Value);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetWorldById(Guid id)
    {
        Result<World> result = await Sender.Send(new GetWorldByIdQuery(id));
        if (result.IsFailure)
            return HandleFailure(result);

        return Ok(result.Value);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateWorldRequest request)
    {
        Result<World> result = await Sender.Send(new CreateWorldCommand(request.Name));

        if (result.IsFailure)
            return HandleFailure(result);

        return Ok(result.Value);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        Result result = await Sender.Send(new RemoveWorldCommand(id));
        if (result.IsFailure)
            return HandleFailure(result);

        return NoContent();
    }
}