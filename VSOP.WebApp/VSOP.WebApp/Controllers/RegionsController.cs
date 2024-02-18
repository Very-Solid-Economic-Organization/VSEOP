using MediatR;
using Microsoft.AspNetCore.Mvc;
using VSOP.Application.Requests.Regions.Commands.CreateRegion;
using VSOP.Application.Requests.Regions.Commands.RemoveRegion;
using VSOP.Application.Requests.Regions.Commands.UpdateRegion;
using VSOP.Application.Requests.Regions.Queries.GetRegionById;
using VSOP.Contracts.Regions;
using VSOP.WebApp.Abstractions;

namespace VSOP.WebApp.Controllers;

[Route("api/[controller]")]
public class RegionsController(ISender sender) : ApiController(sender)
{
    /// <summary>
    /// Получить объект Региона по указанному Id
    /// </summary>
    /// <param name="id">Id Региона</param>
    /// <param name="cancellationToken"></param>
    /// <response code="200">Объект Региона найденный по указанному Id</response>
    /// <response code="204">Объект мира по заданному Id не был найден</response>
    /// <response code="422">Ошибка валидации</response>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    {
        return HandleResult(await Sender.Send(new GetRegionByIdQuery(id), cancellationToken));
    }

    /// <summary>
    /// Создать новый объект Региона
    /// </summary>
    /// <param name="request">Объект параметров для создания региона</param>
    /// <param name="cancellationToken"></param>
    /// <response code="200">Объект Региона создан</response>
    /// <response code="422">Ошибка валидации</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> Create([FromBody] CreateRegionRequest request, CancellationToken cancellationToken)
    {
        return HandleResult(await Sender.Send(new CreateRegionCommand(request.CountryId, request.Name), cancellationToken));
    }

    /// <summary>
    /// Обновить объект Региона
    /// </summary>
    /// <param name="id">Id объекта для Региона для обновления</param>
    /// <param name="request">Объект параметров для обновления региона</param>
    /// <param name="cancellationToken"></param>
    /// <response code="200">Обновленный объект Региона</response>
    /// <response code="422">Ошибка валидации или объект не найден по Id</response>
    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateRegionRequest request, CancellationToken cancellationToken)
    {
        return HandleResult(await Sender.Send(new UpdateRegionCommand(id, request.Name), cancellationToken));
    }


    /// <summary>
    /// Удалить объект Региона найденный по указанному Id
    /// </summary>
    /// <param name="id">Id региона</param>
    /// <param name="cancellationToken"></param>
    /// <response code="204">Объект Региона удален</response>
    /// <response code="422">Ошибка валидации</response>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        return HandleResult(await Sender.Send(new RemoveRegionCommand(id), cancellationToken));
    }
}
