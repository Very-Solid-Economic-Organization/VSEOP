using System.Net;
using VSOP.Application.Abstractions.Messaging;
using VSOP.Application.Data;
using VSOP.Domain.DbModels.Regions;
using VSOP.Domain.Primitives;
using VSOP.Domain.Primitives.Results;

namespace VSOP.Application.Requests.StoredCommodities.Commands.UpdateStoredCommodity
{
    internal sealed class UpdateStoredCommodityCommandHandler : ICommandHandler<UpdateStoredCommodityCommand, StoredCommodity>
    {
        private readonly IStoredCommodityRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateStoredCommodityCommandHandler(IStoredCommodityRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<StoredCommodity>> Handle(UpdateStoredCommodityCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
            if (entity == null)
                return Result.Failure<StoredCommodity>(new Error($"No {nameof(StoredCommodity)} were found for Id {request.Id}"), HttpStatusCode.UnprocessableContent);

            entity.Update(request.quantity, request.selfCost, request.price, request.currentDemand);

            _repository.Update(entity);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success(entity);
        }
    }
}
