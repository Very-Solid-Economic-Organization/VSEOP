using MediatR;
using Microsoft.AspNetCore.Mvc;
using VSOP.Contracts.Factories;
using VSOP.Domain.DbModels.Factories;
using VSOP.Domain.Primitives.Results;
using VSOP.WebApp.Abstractions;

namespace VSOP.WebApp.Controllers;

[Route("api/[controller]")]
public class FactoriesController : ApiController
{
    //TODO: Дождаться создания медиаторов
    public FactoriesController(ISender sender) : base(sender)
    {
    }

    //[HttpGet]
    //public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    //{
    //    Result<List<Factory>> result = await Sender.Send(new GetFactoryListQuery(), cancellationToken);
    //    return HandleResult(result);
    //}

    //[HttpGet("{id:guid}")]
    //public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    //{
    //    Result<Factory> result = await Sender.Send(new GetFactoryByIdQuery(id), cancellationToken);
    //    return HandleResult(result);
    //}

    //[HttpPost]
    //public async Task<IActionResult> Create([FromBody] CreateFactoryRequest request, CancellationToken cancellationToken)
    //{
    //    Result<Factory> result = await Sender.Send(new CreateFactoryCommand(request.Name), cancellationToken);
    //    return HandleResult(result);
    //}

    //[HttpDelete("{id:guid}")]
    //public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    //{
    //    Result result = await Sender.Send(new RemoveFactoryCommand(id), cancellationToken);
    //    return HandleResult(result);
    //}
}
