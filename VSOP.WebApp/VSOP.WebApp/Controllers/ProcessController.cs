using MediatR;
using Microsoft.AspNetCore.Mvc;
using VSOP.Domain.DbModels.Producers;
using VSOP.Domain.Primitives.Results;
using VSOP.WebApp.Abstractions;

namespace VSOP.WebApp.Controllers;

[Route("api/[controller]")]

//TODO: Дождаться создания медиаторов
public class ProcessController : ApiController
{
    public ProcessController(ISender sender) : base(sender)
    {
    }

    //[HttpGet]
    //public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    //{
    //    Result<List<Process>> result = await Sender.Send(new GetProcessListQuery(), cancellationToken);
    //    return HandleResult(result);
    //}

    //[HttpGet("{id:guid}")]
    //public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    //{
    //    Result<Process> result = await Sender.Send(new GetProcessByIdQuery(id), cancellationToken);
    //    return HandleResult(result);
    //}

    //[HttpPost]
    //public async Task<IActionResult> Create([FromBody] CreateProcessRequest request, CancellationToken cancellationToken)
    //{
    //    Result<Process> result = await Sender.Send(new CreateProcessCommand(request.Name), cancellationToken);
    //    return HandleResult(result);
    //}

    //[HttpDelete("{id:guid}")]
    //public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    //{
    //    Result result = await Sender.Send(new RemoveProcessCommand(id), cancellationToken);
    //    return HandleResult(result);
    //}
}
