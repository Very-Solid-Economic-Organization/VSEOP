using MediatR;
using Microsoft.AspNetCore.Mvc;
using VSOP.WebApp.Abstractions;

namespace VSOP.WebApp.Controllers;

[Route("api/[controller]")]
public class FactoriesController : ApiController
{
    //TODO: Дождаться создания медиаторов
    public FactoriesController(ISender sender) : base(sender)
    {
    }


    //[HttpGet("{id:guid}")]
    //[ProducesResponseType(StatusCodes.Status200OK)]
    //[ProducesResponseType(StatusCodes.Status204NoContent)]
    //[ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    //public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    //{
    //    Result<Factory> result = await Sender.Send(new GetFactoryByIdQuery(id), cancellationToken);
    //    return HandleResult(result);
    //}

    //[HttpPost]
    //[ProducesResponseType(StatusCodes.Status200OK)]
    //[ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    //public async Task<IActionResult> Create([FromBody] CreateFactoryRequest request, CancellationToken cancellationToken)
    //{
    //    Result<Factory> result = await Sender.Send(new CreateFactoryCommand(request.Name), cancellationToken);
    //    return HandleResult(result);
    //}

    //[HttpDelete("{id:guid}")]
    //[ProducesResponseType(StatusCodes.Status204NoContent)]
    //[ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    //public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    //{
    //    Result result = await Sender.Send(new RemoveFactoryCommand(id), cancellationToken);
    //    return HandleResult(result);
    //}
}
