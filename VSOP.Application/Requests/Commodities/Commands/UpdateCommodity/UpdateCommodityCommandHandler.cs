using System.Net;
using VSOP.Application.Abstractions.Messaging;
using VSOP.Application.Data;
using VSOP.Domain.DbModels.Commodities;
using VSOP.Domain.Primitives;
using VSOP.Domain.Primitives.Results;

namespace VSOP.Application.Requests.Commodities.Commands.UpdateCommodity
{
    internal sealed class UpdateCommodityCommandHandler : ICommandHandler<UpdateCommodityCommand, Commodity>
    {
        private readonly ICommodityRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCommodityCommandHandler(ICommodityRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Commodity>> Handle(UpdateCommodityCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
            if (entity == null)
                return Result.Failure<Commodity>(new Error(
                    $"No {nameof(Commodity)} were found for Id {request.Id}"), HttpStatusCode.UnprocessableContent);
            entity.Update(request.name);

            _repository.Update(entity);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success(entity);
        }
    }
}
