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
public abstract class ApiController : ControllerBase
{
    protected readonly ISender Sender;
    /// <summary>
    /// 
    /// </summary>
    /// <param name="result">Объект <see cref="Result"/> выполнения</param>
    /// <returns><see cref="IActionResult"/> с описанием ошибок для возврата</returns>
    /// <exception cref="InvalidOperationException">Возвращает исключение если <see cref="Result"/> был положительным </exception>
    public ApiController(ISender sender) => Sender = sender;

    /// <summary>
    /// Метод обработки результата выполнения медиатора
    /// </summary>
    /// <typeparam name="T">Тип вложенного значения объекта ответа</typeparam>
    /// <param name="result">Объект <see cref="Result"/> с успешности и вложенным значением, или неуспешности и ошибкой</param>
    /// <returns><see cref="IActionResult"/> с телом ответа</returns>
    protected IActionResult HandleResult<T>(Result<T> result)
    {
        if (result.Code is HttpStatusCode.OK)
            return Ok(result.Value);

        return HandleNotOkResult(result);
    }

    /// <summary>
    /// Метод обработки результата выполнения медиатора
    /// </summary>
    /// <param name="result">Объект <see cref="Result"/> с указателем успешности или неуспешности и ошибкой</param>
    /// <returns></returns>
    protected IActionResult HandleResult(Result result)
        => HandleNotOkResult(result);

    IActionResult HandleNotOkResult(Result result)
    {
        switch (result.Code) //TODO : добавить другие необходимые статус коды
        {
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

    static ProblemDetails CreateProblemDetails(
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