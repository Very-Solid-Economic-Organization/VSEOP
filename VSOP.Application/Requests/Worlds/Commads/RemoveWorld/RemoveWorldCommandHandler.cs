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
        private readonly IWorldRepository _Repository;
        private readonly IUnitOfWork _unitOfWork;

        public RemoveWorldCommandHandler(IWorldRepository Repository, IUnitOfWork unitOfWork)
        {
            _Repository = Repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(RemoveWorldCommand request, CancellationToken cancellationToken)
        {
            var entity = await _Repository.GetByIdAsync(request.worldGuid, cancellationToken);
            if (entity == null)
                return Result.Failure(new Error(
                HttpStatusCode.NoContent, //TODO: Подумать над HTMLStatusCode подходящим для ситуации
                $"No worlds were found for Id {request.worldGuid}"));

            _Repository.Remove(entity);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
