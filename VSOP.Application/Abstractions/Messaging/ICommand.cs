using MediatR;
using VSOP.Domain.Primitives.Results;

namespace VSOP.Application.Abstractions.Messaging;

public interface ICommand : IRequest<Result>;

public interface ICommand<TResponse> : IRequest<Result<TResponse>>;