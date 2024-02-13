using FluentValidation;
using System.Net;
using VSOP.Application.Abstractions.Messaging;
using VSOP.Application.Data;
using VSOP.Domain.DbModels.Worlds;
using VSOP.Domain.Primitives;
using VSOP.Domain.Primitives.Results;

namespace VSOP.Application.Requests.Worlds.Commads.RemoveWorld
{
    internal sealed class RemoveWorldCommandHandler : ICommandHandler<RemoveWorldCommand>
    {
        private readonly IWorldRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public RemoveWorldCommandHandler(IWorldRepository Repository, IUnitOfWork unitOfWork)
        {
            _repository = Repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(RemoveWorldCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.worldGuid, cancellationToken);
            if (entity == null)
                return Result.Failure(new Error($"No worlds were found for Id {request.worldGuid}"), HttpStatusCode.UnprocessableContent);

            _repository.Remove(entity);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
