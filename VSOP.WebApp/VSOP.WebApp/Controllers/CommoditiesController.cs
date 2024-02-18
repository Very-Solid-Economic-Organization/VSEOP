using MediatR;
using Microsoft.AspNetCore.Mvc;
using VSOP.Application.Requests.Commodities.Commands.CreateCommodity;
using VSOP.Application.Requests.Commodities.Commands.RemoveCommodity;
using VSOP.Application.Requests.Commodities.Commands.UpdateCommodity;
using VSOP.Application.Requests.Commodities.Queries.GetCommodityById;
using VSOP.Contracts.Commodities;
using VSOP.WebApp.Abstractions;

namespace VSOP.WebApp.Controllers;

[Route("api/[controller]")]
public class CommoditiesController(ISender sender) : ApiController(sender)
{
    /// <summary>
    /// Получить Предмет Потребления по указанному Id
    /// </summary>
    /// <param name="id">Id предмета потребления</param>
    /// <param name="cancellationToken"></param>
    /// <response code="200">Объект Предмета Потребления найденный по указанному</response>
    /// <response code="204">Если объект Предмета Потребления по указанному Id не был найден</response>
    /// <response code="422">Ошибка валидации</response>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    {
        return HandleResult(await Sender.Send(new GetCommodityByIdQuery(id), cancellationToken));
    }

    /// <summary>
    /// Создать новый объект Предмета Потребления
    /// </summary>
    /// <param name="request">Объект с параметрами для создания</param>
    /// <param name="cancellationToken"></param>
    /// <response code="200">Созданный Объект Предмета Потребления</response>
    /// <response code="422">Ошибка валидации</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> Create([FromBody] CreateCommodityRequest request, CancellationToken cancellationToken)
    {
        return HandleResult(await Sender.Send(new CreateCommodityCommand(request.WorldId, request.Name), cancellationToken));
    }

    /// <summary>
    /// Обновить объект Предмета Потребления по переданному Id
    /// </summary>
    /// <param name="id">Id Предмета Потребления</param>
    /// <param name="request">Объект с параметрами для обновления</param>
    /// <param name="cancellationToken"></param>
    /// <response code="200">Обновленный объект Предмета Потребления</response>
    /// <response code="422">Ошибка валидации</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateCommodityRequest request, CancellationToken cancellationToken)
    {
        return HandleResult(await Sender.Send(new UpdateCommodityCommand(id, request.Name), cancellationToken));
    }

    /// <summary>
    /// Удалить объект Предмета Потребления найденный по указанному Id
    /// </summary>
    /// <param name="id">Id объекта Предмета Потребления на удаление</param>
    /// <param name="cancellationToken"></param>
    /// <response code="204">Объект Предмета Потребления удален</response>
    /// <response code="422">Ошибка валидации</response>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        return HandleResult(await Sender.Send(new RemoveCommodityCommand(id), cancellationToken));
    }
}