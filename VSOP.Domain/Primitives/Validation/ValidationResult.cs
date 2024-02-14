using VSOP.Domain.Primitives.Results;

namespace VSOP.Domain.Primitives.Validation;
public sealed class ValidationResult : Result, IValidationResult
{
    private ValidationResult(Error[] errors) : base(false, IValidationResult.ValidationError, System.Net.HttpStatusCode.UnprocessableEntity) =>
        Errors = errors;

    public Error[] Errors { get; }

    public static ValidationResult WithErrors(Error[] errors) => new(errors);
}