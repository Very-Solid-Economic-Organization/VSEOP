using MediatR;
using Microsoft.AspNetCore.Mvc;
using VSOP.Application.Requests.StoredCommodities.Commands.CreateStoredCommodity;
using VSOP.Application.Requests.StoredCommodities.Commands.RemoveStoredCommodity;
using VSOP.Application.Requests.StoredCommodities.Commands.UpdateStoredCommodity;
using VSOP.Application.Requests.StoredCommodities.Queries.GetStoredCommodityById;
using VSOP.Contracts.StoredCommodities;
using VSOP.WebApp.Abstractions;

namespace VSOP.WebApp.Controllers;

[Route("api/[controller]")]
public class StoredCommoditiesController : ApiController
{
    public StoredCommoditiesController(ISender sender) : base(sender)
    {
    }

    /// <summary>
    /// Получить объект хранимого предмета потребления
    /// </summary>
    /// <param name="id">Id хранимого предмета потребления</param>
    /// <param name="cancellationToken"></param>
    /// <response code="200">Объект Хранимого Предмета Потребления найденный по указанному Id</response>
    /// <response code="204">Если объекта Хранимого Предмета Потребления по указанному Id не был найден</response>
    /// <response code="422">Ошибка валидации</response>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    {
        return HandleResult(await Sender.Send(new GetStoredCommodityByIdQuery(id), cancellationToken));
    }

    /// <summary>
    /// Создать новый объект Хранимого Предмета Потребления
    /// </summary>
    /// <param name="request">Объект параметров для создания Хранимого Предмета Потребления</param>
    /// <param name="cancellationToken"></param>
    /// <response code="200">Созданный Объект Хранимого Предмета Потребления</response>
    /// <response code="422">Ошибка валидации</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> Create([FromBody] CreateStoredCommodityRequest request, CancellationToken cancellationToken)
    {
        return HandleResult(
            await Sender.Send(new CreateStoredCommodityCommand(
                request.CommodityId, request.Quantity, request.SelfCost, request.Price, request.CurrentDemand), cancellationToken));
    }

    /// <summary>
    /// Обновить объект Хранимого Предмета Потребления
    /// </summary>
    /// <param name="id">Id Хранимого Предмета Потребления</param>
    /// <param name="request">Объект параметров для обновления Хранимого Предмета Потребления</param>
    /// <param name="cancellationToken"></param>
    /// <response code="200">Обновленный Объект Хранимого Предмета Потребления</response>
    /// <response code="422">Ошибка валидации</response>
    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateStoredCommoditiesRequest request, CancellationToken cancellationToken)
    {
        return HandleResult(await Sender.Send(new UpdateStoredCommodityCommand(
            id, request.Quantity, request.SelfCost, request.Price, request.CurrentDemand), cancellationToken));
    }

    /// <summary>
    /// Удалить объект Хранимого Предмета Потребления
    /// </summary>
    /// <param name="id">Id Хранимого Предмета Потребления</param>
    /// <param name="cancellationToken"></param>
    /// <response code="204">Объект Хранимого Предмета Потребления успешно удален</response>
    /// <response code="422">Ошибка валидации</response>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        return HandleResult(await Sender.Send(new RemoveStoredCommodityCommand(id), cancellationToken));
    }
}
