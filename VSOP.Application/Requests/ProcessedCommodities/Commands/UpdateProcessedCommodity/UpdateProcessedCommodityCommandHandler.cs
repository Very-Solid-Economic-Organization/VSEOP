using System.Net;
using VSOP.Application.Abstractions.Messaging;
using VSOP.Application.Data;
using VSOP.Domain.DbModels.Producers;
using VSOP.Domain.Primitives;
using VSOP.Domain.Primitives.Results;

namespace VSOP.Application.Requests.ProcessedCommodities.Commands.UpdateProcessedCommodity
{
    internal sealed class UpdateProcessedCommodityCommandHandler : ICommandHandler<UpdateProcessedCommodityCommand, ProcessedCommodity>
    {
        private readonly IProcessedCommodityRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateProcessedCommodityCommandHandler(IProcessedCommodityRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<ProcessedCommodity>> Handle(UpdateProcessedCommodityCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
            if (entity == null)
                return Result.Failure<ProcessedCommodity>(new Error($"No {nameof(ProcessedCommodity)} were found for Id {request.Id}"), HttpStatusCode.UnprocessableContent);

            entity.Update(request.quantity);

            _repository.Update(entity);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success(entity);
        }
    }
}
