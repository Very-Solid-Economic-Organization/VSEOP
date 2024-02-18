using MediatR;
using Microsoft.AspNetCore.Mvc;
using VSOP.Application.Requests.ProcessedCommodities.Commands.CreateProcessedCommodity;
using VSOP.Application.Requests.ProcessedCommodities.Commands.RemoveProcessedCommodity;
using VSOP.Application.Requests.ProcessedCommodities.Commands.UpdateProcessedCommodity;
using VSOP.Application.Requests.ProcessedCommodities.Queries.GetProcessedCommodityById;
using VSOP.Contracts.ProcessedCommodities;
using VSOP.WebApp.Abstractions;

namespace VSOP.WebApp.Controllers;

[Route("api/[controller]")]
public class ProcessedCommoditiesController(ISender sender) : ApiController(sender)
{
    /// <summary>
    /// Получить объект Обрабатываемого Предмета Потребления найденный по переданному Id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    {
        return HandleResult(await Sender.Send(new GetProcessedCommodityByIdQuery(id), cancellationToken));
    }

    /// <summary>
    /// Создать объект Обрабатываемого Предмета Потребления
    /// </summary>
    /// <param name="request">Объект передаваемых параметров</param>
    /// <param name="cancellationToken"></param>
    /// <response code="200">Созданный объект Обрабатываемого Предмета Потребления</response>
    /// <response code="422">Ошибка валидации переданных параметров</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> Create([FromBody] CreateProcessedCommodityRequest request, CancellationToken cancellationToken)
    {
        return HandleResult(await Sender.Send(
            new CreateProcessedCommodityCommand(request.ProcessId, request.CommodityId, request.Type, request.Quantity), cancellationToken));
    }

    /// <summary>
    /// Обновить объект Обрабатываемого Предмета Потребления найденный по переданному Id
    /// </summary>
    /// <param name="id">Id Обрабатываемого Предмета Потребления</param>
    /// <param name="request">Объект принимаемых параметров</param>
    /// <param name="cancellationToken"></param>
    /// <response code="200">Обновленный объект Обрабатываемого Предмета Потребления</response>
    /// <response code="422">Ошибка валидации переданных параметров</response>
    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateProcessedCommodityRequest request, CancellationToken cancellationToken)
    {
        return HandleResult(await Sender.Send(new UpdateProcessedCommodityCommand(id, request.Quantity), cancellationToken));
    }

    /// <summary>
    /// Удалить объект Обрабатываемого Предмета Потребления найденный по переданному Id
    /// </summary>
    /// <param name="id">Id Обрабатываемого Предмета Потребления</param>
    /// <param name="cancellationToken"></param>
    /// <response code="204">Объект Обрабатываемого Предмета Потребления удален успешно</response>
    /// <response code="422">Ошибка валидации переданных параметров</response>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        return HandleResult(await Sender.Send(new RemoveProcessedCommodityCommand(id), cancellationToken));
    }
}