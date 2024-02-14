using MediatR;
using Microsoft.AspNetCore.Mvc;
using VSOP.Application.Requests.Regions.Commands.CreateRegion;
using VSOP.Application.Requests.Regions.Commands.RemoveRegion;
using VSOP.Application.Requests.Regions.Queries.GetRegionById;
using VSOP.Contracts.Regions;
using VSOP.Domain.DbModels.Regions;
using VSOP.Domain.Primitives.Results;
using VSOP.WebApp.Abstractions;

namespace VSOP.WebApp.Controllers;

[Route("api/[controller]")]
public class RegionsComtroller : ApiController
{
    public RegionsComtroller(ISender sender) : base(sender)
    {
    }

    //[HttpGet]
    //public async Task<IActionResult> GetAll(CancellationToken cancellationToken) //TODO: дождаться создания
    //{
    //    Result<List<Region>> result = await Sender.Send(new GetRegionsListQuery(), cancellationToken);
    //    return HandleResult(result);
    //}

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    {
        return HandleResult(await Sender.Send(new GetRegionByIdQuery(id), cancellationToken));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateRegionRequest request, CancellationToken cancellationToken)
    {
        return HandleResult(await Sender.Send(new CreateRegionCommand(request.CountryId, request.Name), cancellationToken));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        return HandleResult(await Sender.Send(new RemoveRegionCommand(id), cancellationToken));
    }
}
