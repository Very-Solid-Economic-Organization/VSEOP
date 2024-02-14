using MediatR;
using Microsoft.AspNetCore.Mvc;
using VSOP.Application.Requests.Countries.Commands.CreateCountry;
using VSOP.Application.Requests.Countries.Commands.RemoveCountry;
using VSOP.Application.Requests.Countries.Queries.GetCountryById;
using VSOP.Contracts.Countries;
using VSOP.WebApp.Abstractions;

namespace VSOP.WebApp.Controllers;

[Route("api/[controller]")]
public class CountriesController : ApiController
{
    public CountriesController(ISender sender) : base(sender)
    {
    }

    //[HttpGet]
    //public async Task<IActionResult> GetAll(CancellationToken cancellationToken) //TODO: дождаться создания
    //{
    //    Result<List<Country>> result = await Sender.Send(new GetCountryListQuery(), cancellationToken);
    //    return HandleResult(result);
    //}

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    {
        return HandleResult(await Sender.Send(new GetCountryByIdQuery(id), cancellationToken));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCountryRequest request, CancellationToken cancellationToken)
    {
        return HandleResult(await Sender.Send(new CreateCountryCommand(request.WorldId, request.Name), cancellationToken));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken) //TODO: дождаться создания
    {
        return HandleResult(await Sender.Send(new RemoveCountryCommand(id), cancellationToken));
    }
}
