using MediatR;
using Microsoft.AspNetCore.Mvc;
using VSOP.Application.Requests.Factories.Commands.CreateFactory;
using VSOP.Application.Requests.Factories.Commands.RemoveFactory;
using VSOP.Application.Requests.Factories.Commands.UpdateFactory;
using VSOP.Application.Requests.Factories.Queries.GetFactoryById;
using VSOP.Application.Requests.Producers.Commands.AddProcess;
using VSOP.Contracts.Factories;
using VSOP.WebApp.Abstractions;

namespace VSOP.WebApp.Controllers;

[Route("api/[controller]")]
public class FactoriesController(ISender sender) : ApiController(sender)
{
    /// <summary>
    /// Получить объект завода по Id
    /// </summary>
    /// <param name="id">Id завода</param>
    /// <param name="cancellationToken"></param>
    /// <response code="200">Объект Завода</response>
    /// <response code="422">Если объект был не найден</response>
    /// <response code="422">Ошибка валидации или объект не найден по Id</response>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    {
        return HandleResult(await Sender.Send(new GetFactoryByIdQuery(id), cancellationToken));
    }

    /// <summary>
    /// Создать объект завода
    /// </summary>
    /// <param name="request">Объект параметров для создания</param>
    /// <param name="cancellationToken"></param>
    /// <response code="200">Обновленный объект Завода</response>
    /// <response code="422">Ошибка валидации или объект не найден по Id</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> Create([FromBody] CreateFactoryRequest request, CancellationToken cancellationToken)
    {
        return HandleResult(await Sender.Send(new CreateFactoryCommand(request.RegionId, request.Name), cancellationToken));
    }

    /// <summary>
    /// Обновить объект Завода
    /// </summary>
    /// <param name="id">Id объекта Завода</param>
    /// <param name="request">Объект параметров для обновления</param>
    /// <param name="cancellationToken"></param>
    /// <response code="200">Обновленный объект Завода</response>
    /// <response code="422">Ошибка валидации или объект не найден по Id</response>
    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateFactoryRequest request, CancellationToken cancellationToken)
    {
        return HandleResult(await Sender.Send(new UpdateFactoryCommand(id, request.Name), cancellationToken));
    }

    /// <summary>
    /// Удалить объект Завода переданный по Id
    /// </summary>
    /// <param name="id">Id Завода</param>
    /// <param name="cancellationToken"></param>
    /// <response code="204">Объект Завода успешно удален</response>
    /// <response code="422">Ошибка валидации или объект не найден по Id</response>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        return HandleResult(await Sender.Send(new RemoveFactoryCommand(id), cancellationToken));
    }
}