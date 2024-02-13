﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using VSOP.WebApp.Abstractions;

namespace VSOP.WebApp.Controllers;

[Route("api/[controller]")]
public class ProcessedCommoditiesController : ApiController
{

    //TODO: Дождаться создания медиаторов
    public ProcessedCommoditiesController(ISender sender) : base(sender)
    {
    }

    //[HttpGet("{id:guid}")]
    //public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    //{
    //    Result<ProcessedCommodity> result = await Sender.Send(new GetProcessedCommodityByIdQuery(id), cancellationToken);
    //    return HandleResult(result);
    //}

    //[HttpPost]
    //public async Task<IActionResult> Create([FromBody] CreateProcessedCommodityRequest request, CancellationToken cancellationToken)
    //{
    //    Result<ProcessedCommodity> result = await Sender.Send(new CreateProcessedCommodityCommand(request.Name), cancellationToken);
    //    return HandleResult(result);
    //}

    //[HttpDelete("{id:guid}")]
    //public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    //{
    //    Result result = await Sender.Send(new RemoveProcessedCommodityCommand(id), cancellationToken);
    //    return HandleResult(result);
    //}
}