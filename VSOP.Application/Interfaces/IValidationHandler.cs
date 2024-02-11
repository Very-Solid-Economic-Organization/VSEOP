using VSOP.Domain.Primitives.Results;

namespace FSOP.Application.Interfaces
{
    public interface IValidationHandler { }
    public interface IValidationHandler<T> : IValidationHandler
    {
        Task<Result<T>> Validate(T request);
    }

}
