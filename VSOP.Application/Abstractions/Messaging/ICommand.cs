using MediatR;
using VSOP.Models.Primitives.Results;

namespace VSOP.Application.Abstractions.Messaging;

public interface ICommand : IRequest<Result>;

public interface ICommand<TResponse> : IRequest<Result<TResponse>>;