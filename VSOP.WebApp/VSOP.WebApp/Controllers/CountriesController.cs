using MediatR;
using Microsoft.AspNetCore.Mvc;
using VSOP.Application.Requests.Countries.Commands.CreateCountry;
using VSOP.Application.Requests.Countries.Commands.RemoveCountry;
using VSOP.Application.Requests.Countries.Queries.GetCountryById;
using VSOP.Contracts.Countries;
using VSOP.WebApp.Abstractions;

namespace VSOP.WebApp.Controllers;

[Route("api/[controller]")]
public class CountriesController(ISender sender) : ApiController(sender)
{
    /// <summary>
    /// Возвращает страну найденную по указанному Id
    /// </summary>
    /// <param name="id">Id страны</param>
    /// <param name="cancellationToken"></param>
    /// <response code="200">Объект Страны найденный по указанному</response>
    /// <response code="204">Если объект Страны по указанному Id не был найден</response>
    /// <response code="422">Ошибка валидации</response>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    {
        return HandleResult(await Sender.Send(new GetCountryByIdQuery(id), cancellationToken));
    }

    /// <summary>
    /// Создает новый объект Страны
    /// </summary>
    /// <param name="request">Объект принимаемых параметров</param>
    /// <param name="cancellationToken"></param>
    /// <response code="200">Новый объект Страны</response>
    /// <response code="422">Ошибка валидации переданных параметров</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> Create([FromBody] CreateCountryRequest request, CancellationToken cancellationToken)
    {
        return HandleResult(await Sender.Send(new CreateCountryCommand(request.WorldId, request.Name), cancellationToken));
    }

    /// <summary>
    /// Удаляет объект Страны найденный по указанному Id
    /// </summary>
    /// <param name="id">Id Страны для удаления</param>
    /// <param name="cancellationToken"></param>
    /// <response code="204">Объект Страны был успешно удален</response>
    /// <response code="422">По переданному Id не было найдено стран или ошибка валидации</response>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        return HandleResult(await Sender.Send(new RemoveCountryCommand(id), cancellationToken));
    }
}
