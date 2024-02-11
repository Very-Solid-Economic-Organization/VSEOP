using MediatR;
using VSOP.Domain.Primitives.Results;

namespace VSOP.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>;