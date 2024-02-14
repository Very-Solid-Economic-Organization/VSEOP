using VSOP.Domain.Primitives.Results;

namespace VSOP.Domain.Primitives.Validation;
public sealed class ValidationResult<TValue> : Result<TValue>, IValidationResult
{
    private ValidationResult(Error[] errors)
        : base(default, false, IValidationResult.ValidationError, System.Net.HttpStatusCode.UnprocessableEntity) =>
        Errors = errors;

    public Error[] Errors { get; }

    public static ValidationResult<TValue> WithErrors(Error[] errors) => new(errors);
}