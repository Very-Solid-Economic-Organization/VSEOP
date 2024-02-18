using System.Net;
using VSOP.Application.Abstractions.Messaging;
using VSOP.Application.Data;
using VSOP.Domain.DbModels.Commodities;
using VSOP.Domain.DbModels.Enums;
using VSOP.Domain.DbModels.Producers;
using VSOP.Domain.Primitives;
using VSOP.Domain.Primitives.Results;

namespace VSOP.Application.Requests.ProcessedCommodities.Commands.CreateProcessedCommodity
{
    internal sealed class CreateProcessedCommodityCommandHandler : ICommandHandler<CreateProcessedCommodityCommand, ProcessedCommodity>
    {
        private readonly IProcessedCommodityRepository _processedCommodityRepository;
        private readonly ICommodityRepository _commodityRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateProcessedCommodityCommandHandler(IProcessedCommodityRepository processedCommodityRepository, ICommodityRepository commodityRepository, IUnitOfWork unitOfWork)
        {
            _processedCommodityRepository = processedCommodityRepository;
            _commodityRepository = commodityRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<ProcessedCommodity>> Handle(CreateProcessedCommodityCommand request, CancellationToken cancellationToken)
        {
            if (!await _commodityRepository.AnyAsync(x => x.Id == request.commodityId, cancellationToken))
                return Result.Failure<ProcessedCommodity>(new Error($"{nameof(Commodity)} was not found by Id - {request.commodityId}"), HttpStatusCode.UnprocessableContent);

            ProcessedCommodity entity;
            if ((ProcessedCommodityType)request.processedCommodityType == ProcessedCommodityType.Used)
                entity = ProcessedCommodity.CreateConsumedCommodity(request.processId, request.commodityId, request.quantity);
            else
                entity = ProcessedCommodity.CreateProducedCommodity(request.processId, request.commodityId, request.quantity);

            await _processedCommodityRepository.AddAsync(entity, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success(entity);
        }
    }
}
