﻿using MediatR;
using VSOP.Models.Primitives.Results;

namespace VSOP.Application.Abstractions.Messaging;

public interface IQueryHandler<TQuery, TResponse>
    : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>;
