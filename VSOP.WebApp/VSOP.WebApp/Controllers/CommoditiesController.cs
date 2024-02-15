using MediatR;
using Microsoft.AspNetCore.Mvc;
using VSOP.Application.Requests.Commodities.Commands.CreateCommodity;
using VSOP.Application.Requests.Commodities.Commands.RemoveCommodity;
using VSOP.Application.Requests.Commodities.Queries.GetCommodityById;
using VSOP.Contracts.Commodities;
using VSOP.WebApp.Abstractions;

namespace VSOP.WebApp.Controllers;

[Route("api/[controller]")]
public class CommoditiesController : ApiController
{
    //TODO: Дождаться создания медиаторов
    public CommoditiesController(ISender sender) : base(sender)
    {
    }

    //[HttpGet]
    //public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    //{
    //    Result<List<Commodity>> result = await Sender.Send(new GetCommodityListQuery(), cancellationToken);
    //    return HandleResult(result);
    //}

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    {
        return HandleResult(await Sender.Send(new GetCommodityByIdQuery(id), cancellationToken));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCommodityRequest request, CancellationToken cancellationToken)
    {
        return HandleResult(await Sender.Send(new CreateCommodityCommand(request.WorldId, request.Name), cancellationToken));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        return HandleResult(await Sender.Send(new RemoveCommodityCommand(id), cancellationToken));
    }
}