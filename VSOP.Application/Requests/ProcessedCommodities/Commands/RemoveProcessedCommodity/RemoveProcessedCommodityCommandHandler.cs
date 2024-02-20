using System.Net;
using VSOP.Application.Abstractions.Messaging;
using VSOP.Application.Data;
using VSOP.Domain.DbModels.Processes.ProcessedCommodities;
using VSOP.Domain.Primitives;
using VSOP.Domain.Primitives.Results;

namespace VSOP.Application.Requests.ProcessedCommodities.Commands.RemoveProcessedCommodity
{
    internal sealed class RemoveProcessedCommodityCommandHandler : ICommandHandler<RemoveProcessedCommodityCommand>
    {
        private readonly IProcessedCommodityRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public RemoveProcessedCommodityCommandHandler(IProcessedCommodityRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(RemoveProcessedCommodityCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);

            if (entity == null)
                return Result.Failure(new Error($"No {nameof(ProcessedCommodity)} were found for Id {request.Id}"), HttpStatusCode.UnprocessableContent);

            _repository.Remove(entity);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success(HttpStatusCode.NoContent);
        }
    }
}
