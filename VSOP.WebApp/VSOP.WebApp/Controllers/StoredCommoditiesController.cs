using MediatR;
using Microsoft.AspNetCore.Mvc;
using VSOP.Contracts.StoredCommodities;
using VSOP.Domain.DbModels.Regions;
using VSOP.Domain.Primitives.Results;
using VSOP.WebApp.Abstractions;

namespace VSOP.WebApp.Controllers;

[Route("api/[controller]")]
public class StoredCommoditiesController : ApiController
{
    //TODO: Дождаться создания медиаторов
    public StoredCommoditiesController(ISender sender) : base(sender)
    {
    }

    //[HttpGet("{id:guid}")]
    //public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    //{
    //    Result<StoredCommodity> result = await Sender.Send(new GetStoredCommodityByIdQuery(id), cancellationToken);
    //    return HandleResult(result);
    //}

    //[HttpPost]
    //public async Task<IActionResult> Create([FromBody] CreateStoredCommodityRequest request, CancellationToken cancellationToken)
    //{
    //    Result<StoredCommodity> result = await Sender.Send(new CreateStoredCommodityCommand(request.Name), cancellationToken);
    //    return HandleResult(result);
    //}

    //[HttpDelete("{id:guid}")]
    //public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    //{
    //    Result result = await Sender.Send(new RemoveStoredCommodityCommand(id), cancellationToken);
    //    return HandleResult(result);
    //}
}
