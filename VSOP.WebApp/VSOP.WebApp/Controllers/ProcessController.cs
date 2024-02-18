using MediatR;
using Microsoft.AspNetCore.Mvc;
using VSOP.Application.Requests.Processes.Commands.CreateProcess;
using VSOP.Application.Requests.Processes.Commands.RemoveProcess;
using VSOP.Application.Requests.Processes.Commands.UpdateProcess;
using VSOP.Application.Requests.Processes.Queries.GetProcessById;
using VSOP.Contracts.Process;
using VSOP.WebApp.Abstractions;

namespace VSOP.WebApp.Controllers;

[Route("api/[controller]")]

//TODO: Дождаться создания медиаторов
public class ProcessController(ISender sender) : ApiController(sender)
{
    /// <summary>
    /// Получить объект Процесса Производства по переданному Id
    /// </summary>
    /// <param name="id">Id Процесса Производства</param>
    /// <param name="cancellationToken"></param>
    /// <response code="200">Объект Производственного Процесса</response>
    /// <response code="422">Ошибка валидации или объект не найден по Id</response>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    {
        return HandleResult(await Sender.Send(new GetProcessByIdQuery(id), cancellationToken));
    }

    /// <summary>
    /// Создать объект Процесса Производства по переданному Id
    /// </summary>
    /// <param name="request">Объект переданных параметров</param>
    /// <param name="cancellationToken"></param>
    /// <response code="200">Созданный объект Производственного Процесса</response>
    /// <response code="422">Ошибка валидации или объект не найден по Id</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> Create([FromBody] CreateProcessRequest request, CancellationToken cancellationToken)
    {
        return HandleResult(await Sender.Send(new CreateProcessCommand(request.ProcessesCount, request.Name), cancellationToken));
    }

    /// <summary>
    /// Обновить объект Производственного Процесса
    /// </summary>
    /// <param name="id">Id объекта Производственного Процесса</param>
    /// <param name="request">Объект параметров для обновления</param>
    /// <param name="cancellationToken"></param>
    /// <response code="200">Обновленный объект Производственного Процесса</response>
    /// <response code="422">Ошибка валидации или объект не найден по Id</response>
    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateProcessRequest request, CancellationToken cancellationToken)
    {
        return HandleResult(await Sender.Send(new UpdateProcessCommand(id, request.ProcessesCount, request.Name), cancellationToken));
    }

    /// <summary>
    /// Удалить объект Производственного Процесса найденный по переданному Id
    /// </summary>
    /// <param name="id">Id Производственного Процесса</param>
    /// <param name="cancellationToken"></param>
    /// <response code="200">Объект Производственного Процесса успешно удален</response>
    /// <response code="422">Ошибка валидации или объект не найден по Id</response>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        return HandleResult(await Sender.Send(new RemoveProcessCommand(id), cancellationToken));
    }
}
