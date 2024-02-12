using MediatR;
using Microsoft.AspNetCore.Mvc;
using VSOP.Domain.Primitives;
using VSOP.Domain.Primitives.Results;
using VSOP.Domain.Primitives.Validation;

namespace VSOP.WebApp.Abstractions; //Пока поживет тут, потом переедет

[ApiController]
public abstract class ApiController : ControllerBase
{
    protected readonly ISender Sender;

    public ApiController(ISender sender) => Sender = sender;

    protected IActionResult HandleFailure(Result result) =>
        result switch
        {
            { IsSuccess: true } => throw new InvalidOperationException("Handle failure can't be called for successful result"),
            IValidationResult validationResult =>
            BadRequest(
                CreateProblemDetails(
                    "Validation Error", StatusCodes.Status400BadRequest,
                    result.Error,
                    validationResult.Errors)),
            _ =>
                BadRequest(
                    CreateProblemDetails("Bad Request", StatusCodes.Status400BadRequest, result.Error))
        };

    static ProblemDetails CreateProblemDetails(
        string title,
        int status,
        Error error,
        Error[]? errors = null) =>
        new()
        {
            Title = title,
            Type = error.Code.ToString(),
            Detail = error.Message,
            Status = status,
            Extensions = { { nameof(errors), errors } }
        };
}