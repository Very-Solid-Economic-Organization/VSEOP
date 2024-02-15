using System.Net;
using VSOP.Application.Abstractions.Messaging;
using VSOP.Application.Data;
using VSOP.Domain.DbModels.Commodities;
using VSOP.Domain.DbModels.Worlds;
using VSOP.Domain.Primitives;
using VSOP.Domain.Primitives.Results;

namespace VSOP.Application.Requests.Commodities.Commands.CreateCommodity
{
    internal sealed class CreateCommodityCommandHandler : ICommandHandler<CreateCommodityCommand, Commodity>
    {
        private readonly ICommodityRepository _commodityRepository;
        private readonly IWorldRepository _worldRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCommodityCommandHandler(ICommodityRepository commodityRepository, IWorldRepository worldRepository, IUnitOfWork unitOfWork)
        {
            _commodityRepository = commodityRepository;
            _worldRepository = worldRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Commodity>> Handle(CreateCommodityCommand request, CancellationToken cancellationToken)
        {
            if (!await _worldRepository.AnyAsync(x => x.Id == request.WorldId, cancellationToken))
                return Result.Failure<Commodity>(new Error($"{nameof(World)} was not found by Id - {request.WorldId}"), HttpStatusCode.UnprocessableContent);

            var entity = Commodity.Create(request.WorldId, request.name);

            await _commodityRepository.AddAsync(entity, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success(entity);
        }
    }
}
