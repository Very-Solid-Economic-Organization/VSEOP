﻿using FluentValidation;
using System.Net;
using VSOP.Application.Abstractions.Messaging;
using VSOP.Application.Data;
using VSOP.Domain.DbModels.Worlds;
using VSOP.Domain.Primitives;
using VSOP.Domain.Primitives.Results;

namespace VSOP.Application.Requests.Worlds.Commads.UpdateWorld;

internal sealed class UpdateWorldCommandHandler : ICommandHandler<UpdateWorldCommand, World>
{
    private readonly IWorldRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateWorldCommandHandler(IWorldRepository Repository, IUnitOfWork unitOfWork)
    {
        _repository = Repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<World>> Handle(UpdateWorldCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null)
            return Result.Failure<World>(new Error($"{nameof(World)} was not found by Id - {request.Id}"), HttpStatusCode.UnprocessableContent);

        entity.Update(request.Name);

        _repository.Update(entity);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(entity);
    }
}
