using MediatR;
using VSOP.Models.Primitives.Results;

namespace VSOP.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>;