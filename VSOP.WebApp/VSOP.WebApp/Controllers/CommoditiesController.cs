using MediatR;
using Microsoft.AspNetCore.Mvc;
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

    //[HttpGet("{id:guid}")]
    //public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    //{
    //    Result<Commodity> result = await Sender.Send(new GetCommodityByIdQuery(id), cancellationToken);
    //    return HandleResult(result);
    //}

    //[HttpPost]
    //public async Task<IActionResult> Create([FromBody] CreateCommodityRequest request, CancellationToken cancellationToken)
    //{
    //    Result<Commodity> result = await Sender.Send(new CreateCommodityCommand(request.Name), cancellationToken);
    //    return HandleResult(result);
    //}

    //[HttpDelete("{id:guid}")]
    //public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    //{
    //    Result result = await Sender.Send(new RemoveCommodityCommand(id), cancellationToken);
    //    return HandleResult(result);
    //}
}