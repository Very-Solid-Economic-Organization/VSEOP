using MediatR;
using Microsoft.AspNetCore.Mvc;
using VSOP.Application.Requests.Countries.Commands.CreateCountry;
using VSOP.Application.Requests.Countries.Queries.GetCountryById;
using VSOP.Contracts.Countries;
using VSOP.Domain.DbModels.Countries;
using VSOP.Domain.Primitives.Results;
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
        Result<Country> result = await Sender.Send(new GetCountryByIdQuery(id), cancellationToken);
        return HandleResult(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCountryRequest request, CancellationToken cancellationToken)
    {
        Result<Country> result = await Sender.Send(new CreateCountryCommand(request.WorldId, request.Name), cancellationToken);
        return HandleResult(result);
    }

    //[HttpDelete("{id:guid}")]
    //public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken) //TODO: дождаться создания
    //{
    //    Result result = await Sender.Send(new RemoveCountryCommand(id), cancellationToken);
    //    return HandleResult(result);
    //}
}
