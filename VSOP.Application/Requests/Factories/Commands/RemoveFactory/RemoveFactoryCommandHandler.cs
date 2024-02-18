﻿using System.Net;
using VSOP.Application.Abstractions.Messaging;
using VSOP.Application.Data;
using VSOP.Domain.DbModels.Factories;
using VSOP.Domain.Primitives;
using VSOP.Domain.Primitives.Results;

namespace VSOP.Application.Requests.Factories.Commands.RemoveFactory
{
    internal sealed class RemoveFactoryCommandHandler : ICommandHandler<RemoveFactoryCommand>
    {
        private readonly IFactoryRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public RemoveFactoryCommandHandler(IFactoryRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(RemoveFactoryCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);

            if (entity == null)
                return Result.Failure(new Error($"No {nameof(Factory)} were found for Id {request.Id}"), HttpStatusCode.UnprocessableContent);

            _repository.Remove(entity);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success(HttpStatusCode.NoContent);
        }
    }
}