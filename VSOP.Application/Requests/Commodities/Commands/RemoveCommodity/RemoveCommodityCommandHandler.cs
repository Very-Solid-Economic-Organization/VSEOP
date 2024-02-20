using System.Net;
using VSOP.Application.Abstractions.Messaging;
using VSOP.Application.Data;
using VSOP.Domain.DbModels.Commodities;
using VSOP.Domain.DbModels.Processes.ProcessedCommodities;
using VSOP.Domain.Primitives;
using VSOP.Domain.Primitives.Results;

namespace VSOP.Application.Requests.Commodities.Commands.RemoveCommodity
{
    internal sealed class RemoveCommodityCommandHandler : ICommandHandler<RemoveCommodityCommand>
    {
        private readonly ICommodityRepository _repository;
        private readonly IProcessedCommodityRepository _procRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RemoveCommodityCommandHandler(ICommodityRepository repository, IProcessedCommodityRepository procRepository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _procRepository = procRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(RemoveCommodityCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);

            if (entity == null)
                return Result.Failure(new Error($"No {nameof(Commodity)} were found for Id {request.Id}"), HttpStatusCode.UnprocessableContent);

            if (await _procRepository.AnyAsync(x => x.CommodityId == entity.Id, cancellationToken))
                return Result.Failure(new Error($"Unable to remove {nameof(Commodity)}, while exists at least one {nameof(ProcessedCommodity)} linked to it."));

            _repository.Remove(entity);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success(HttpStatusCode.NoContent);
        }
    }
}
