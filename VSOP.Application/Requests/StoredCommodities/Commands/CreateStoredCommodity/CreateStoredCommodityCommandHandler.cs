using System.Net;
using VSOP.Application.Abstractions.Messaging;
using VSOP.Application.Data;
using VSOP.Domain.DbModels.Commodities;
using VSOP.Domain.DbModels.Regions;
using VSOP.Domain.Primitives;
using VSOP.Domain.Primitives.Results;

namespace VSOP.Application.Requests.StoredCommodities.Commands.CreateStoredCommodity
{
    internal sealed class CreateStoredCommodityCommandHandler : ICommandHandler<CreateStoredCommodityCommand, StoredCommodity>
    {
        private readonly IStoredCommodityRepository _storedCommodityRepository;
        private readonly ICommodityRepository _commodityRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateStoredCommodityCommandHandler(IStoredCommodityRepository storedCommodityRepository, ICommodityRepository commodityRepository, IUnitOfWork unitOfWork)
        {
            _storedCommodityRepository = storedCommodityRepository;
            _commodityRepository = commodityRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<StoredCommodity>> Handle(CreateStoredCommodityCommand request, CancellationToken cancellationToken)
        {
            if (!await _commodityRepository.AnyAsync(x => x.Id == request.commodityId, cancellationToken))
                return Result.Failure<StoredCommodity>(new Error($"{nameof(Commodity)} was not found by Id - {request.commodityId}"), HttpStatusCode.UnprocessableContent);

            var entity = StoredCommodity.Create(request.commodityId, request.quantity, request.selfCost, request.price, request.currentDemand);

            await _storedCommodityRepository.AddAsync(entity, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success(entity);
        }
    }
}
