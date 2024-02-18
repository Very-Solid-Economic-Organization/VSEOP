using System.Net;
using VSOP.Application.Abstractions.Messaging;
using VSOP.Application.Data;
using VSOP.Domain.DbModels.Regions;
using VSOP.Domain.Primitives;
using VSOP.Domain.Primitives.Results;

namespace VSOP.Application.Requests.StoredCommodities.Commands.RemoveStoredCommodity
{
    internal sealed class RemoveStoredCommodityCommandHandler : ICommandHandler<RemoveStoredCommodityCommand>
    {
        private readonly IStoredCommodityRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public RemoveStoredCommodityCommandHandler(IStoredCommodityRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(RemoveStoredCommodityCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);

            if (entity == null)
                return Result.Failure(new Error($"No {nameof(StoredCommodity)} were found for Id {request.Id}"), HttpStatusCode.UnprocessableContent);

            _repository.Remove(entity);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success(HttpStatusCode.NoContent);
        }
    }
}
