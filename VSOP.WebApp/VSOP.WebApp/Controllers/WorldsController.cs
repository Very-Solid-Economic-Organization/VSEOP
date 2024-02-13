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
    public async Task<IActionResult> GetWorlds(CancellationToken cancellationToken)
    {
        Result<List<World>> result = await Sender.Send(new GetWorldListQuery(), cancellationToken);
        return HandleResult(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetWorldById(Guid id, CancellationToken cancellationToken)
    {
        Result<World> result = await Sender.Send(new GetWorldByIdQuery(id), cancellationToken);
        return HandleResult(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateWorldRequest request, CancellationToken cancellationToken)
    {
        Result<World> result = await Sender.Send(new CreateWorldCommand(request.Name), cancellationToken);
        return HandleResult(result);
    }

    //[HttpDelete("{id:guid}")]
    //public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    //{
    //    Result result = await Sender.Send(new RemoveWorldCommand(id), cancellationToken);
    //    return HandleResult(result);
    //}
}