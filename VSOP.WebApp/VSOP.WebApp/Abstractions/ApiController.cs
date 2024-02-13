using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using VSOP.Domain.Primitives;
using VSOP.Domain.Primitives.Results;
using VSOP.Domain.Primitives.Validation;

namespace VSOP.WebApp.Abstractions; //Пока поживет тут, потом переедет

/// <summary>
/// Базовое представление ApiContoller-а
/// </summary>
[ApiController]
public abstract class ApiController : ControllerBase //TODO: Разнести HTTP-коды
{
    protected readonly ISender Sender;

    public ApiController(ISender sender) => Sender = sender;

    /// <summary>
    /// Метод обработки <see cref="Result"/> выполнения
    /// </summary>
    /// <param name="result">Объект <see cref="Result"/> выполнения</param>
    /// <returns><see cref="IActionResult"/> с описанием ошибок для возврата</returns>
    /// <exception cref="InvalidOperationException">Возвращает исключение если <see cref="Result"/> был положительным </exception>
    protected IActionResult HandleResult<T>(Result<T> result)
    {
        switch (result.Code) //TODO : добавить другие необходимые статус коды
        {
            case HttpStatusCode.OK: return Ok(result.Value);

            case HttpStatusCode.NoContent: return NoContent();

            case HttpStatusCode.UnprocessableContent: 
                return UnprocessableEntity(
                CreateProblemDetails(
                    "Validation failure", StatusCodes.Status422UnprocessableEntity,
                    result.Error,
                    ((IValidationResult)result).Errors));

            case HttpStatusCode.BadRequest:
                return BadRequest(
                CreateProblemDetails(
                    "Bad Request", StatusCodes.Status400BadRequest,
                    result.Error));



            default:
                return BadRequest(CreateProblemDetails("Bad Request", StatusCodes.Status400BadRequest, result.Error));
        }
    }

    static ProblemDetails CreateProblemDetails( //TODO: Изменить построение статусов
        string title,
        int status,
        Error error,
        Error[]? errors = null) =>
        new()
        {
            Title = title,
            Type = "Error",
            Detail = error.Message,
            Status = status,
            Extensions = { { nameof(errors), errors } }
        };
}