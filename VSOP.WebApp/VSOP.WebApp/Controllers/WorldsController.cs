using MediatR;
using Microsoft.AspNetCore.Mvc;
using VSOP.Application.Requests.Worlds.Commads.CreateWorld;
using VSOP.Application.Requests.Worlds.Commads.RemoveWorld;
using VSOP.Application.Requests.Worlds.Commads.UpdateWorld;
using VSOP.Application.Requests.Worlds.Queries.GetWorldById;
using VSOP.Application.Requests.Worlds.Queries.GetWorldList;
using VSOP.Contracts.Worlds;
using VSOP.WebApp.Abstractions;

namespace VSOP.WebApp.Controllers;

[Route("api/[controller]")]
public class WorldsController(ISender sender) : ApiController(sender)
{

    /// <summary>
    /// Получить список всех Миров
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <remarks>
    /// </remarks>
    /// <returns>Список всех Миров</returns>
    /// <response code="200">Список всех Миров</response>
    /// <response code="204">Если ни одного объекта Мира не найдено</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        return HandleResult(await Sender.Send(new GetWorldListQuery(), cancellationToken));
    }

    /// <summary>
    /// Получить объект Мира найденный по указанному Id
    /// </summary>
    /// <param name="id">Id Мира</param>
    /// <param name="cancellationToken"></param>
    /// <response code="200">Объект Мир найденный по заданному Id</response>
    /// <response code="204">Если объект Мира по указанному Id не был найден</response>
    /// <response code="422">Ошибка валидации</response>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    {
        return HandleResult(await Sender.Send(new GetWorldByIdQuery(id), cancellationToken));
    }

    /// <summary>
    /// Создать новый объект Мира
    /// </summary>
    /// <param name="request">Объект принимаемых параметров</param>
    /// <param name="cancellationToken"></param>
    /// <response code="200">Новый объект Мир</response>
    /// <response code="422">Если произошла ошибка валидации параметров переданного объекта</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> Create([FromBody] CreateWorldRequest request, CancellationToken cancellationToken)
    {
        return HandleResult(await Sender.Send(new CreateWorldCommand(request.Name), cancellationToken));
    }

    /// <summary>
    /// Обновить объект Мира найденный по переданному Id
    /// </summary>
    /// <param name="id">Id Мира</param>
    /// <param name="request">Объект принимаемых параметров</param>
    /// <param name="cancellationToken"></param>
    /// <response code="200">Обновленный объект Мира</response>
    /// <response code="422">Если произошла ошибка валидации параметров переданного объекта или объект был не найден по Id</response>
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateWorldRequest request, CancellationToken cancellationToken)
    {
        return HandleResult(await Sender.Send(new UpdateWorldCommand(id, request.Name), cancellationToken));
    }

    /// <summary>
    /// Удалить объект Мир найденный по заданному Id
    /// </summary>
    /// <param name="id">Id объекта</param>
    /// <param name="cancellationToken"></param>
    /// <response code="204">При успешном удалении Мира</response>
    /// <response code="422">Если по переданному Id не было найденно записей или произошла ошибка валидации</response>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        return HandleResult(await Sender.Send(new RemoveWorldCommand(id), cancellationToken));
    }
}