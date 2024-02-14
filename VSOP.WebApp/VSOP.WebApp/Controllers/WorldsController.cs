using MediatR;
using Microsoft.AspNetCore.Mvc;
using VSOP.Application.Requests.Worlds.Commads.CreateWorld;
using VSOP.Application.Requests.Worlds.Commads.RemoveWorld;
using VSOP.Application.Requests.Worlds.Queries.GetWorldById;
using VSOP.Application.Requests.Worlds.Queries.GetWorldList;
using VSOP.Contracts.Worlds;
using VSOP.Domain.DbModels.Worlds;
using VSOP.Domain.Primitives.Results;
using VSOP.WebApp.Abstractions;

namespace VSOP.WebApp.Controllers;

[Route("api/[controller]")]
public class WorldsController : ApiController
{
    public WorldsController(ISender sender) : base(sender)
    { }

    /// <summary>
    /// Возвращает список всех Миров из базы данных
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <remarks>
    /// </remarks>
    /// <returns>Список всех Миров в базе данных</returns>
    /// <response code="200">Список всех Миров в базе данных</response>
    /// <response code="204">Если в базе данных нет Миров</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        return HandleResult(await Sender.Send(new GetWorldListQuery(), cancellationToken));
    }

    /// <summary>
    /// Возвращает конкретный Мир найденный по заданному Id
    /// </summary>
    /// <param name="id">Id мира</param>
    /// <param name="cancellationToken"></param>
    /// <remarks>
    /// </remarks>
    /// <returns>Объект Мир найденный по заданному Id</returns>
    /// <response code="200">Объект Мир найденный по заданному Id</response>
    /// <response code="204">Если в базе данный объект мира по Id был не найден</response>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    {
        return HandleResult(await Sender.Send(new GetWorldByIdQuery(id), cancellationToken));
    }

    /// <summary>
    /// Создает новый объект Мир в базе данных из переданных параметров в объекте <see cref="CreateWorldRequest"/>
    /// </summary>
    /// <param name="request">Объект принимаемых параметров</param>
    /// <param name="cancellationToken"></param>
    /// <remarks>
    /// </remarks>
    /// <returns>Новый объект Мир</returns>
    /// <response code="200">Новый объект Мир</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Create([FromBody] CreateWorldRequest request, CancellationToken cancellationToken)
    {
        return HandleResult(await Sender.Send(new CreateWorldCommand(request.Name), cancellationToken));
    }

    /// <summary>
    /// Удаляет конкретный объект Мир в базе данных найденный по переданному Id
    /// </summary>
    /// <param name="id">Id объекта для удаление</param>
    /// <param name="cancellationToken"></param>
    /// <remarks>
    /// </remarks>
    /// <returns>NoContent Http response</returns>
    /// <response code="200">При успешном удалении Мира из базы данных</response>
    /// <response code="422">Если по переданному Id не было найденно записей в базе данных</response>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)] //Возможно тоже NoContent
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        return HandleResult(await Sender.Send(new RemoveWorldCommand(id), cancellationToken));
    }
}