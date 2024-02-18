using System.Net;
using VSOP.Application.Abstractions.Messaging;
using VSOP.Application.Data;
using VSOP.Domain.DbModels.Factories;
using VSOP.Domain.Primitives;
using VSOP.Domain.Primitives.Results;

namespace VSOP.Application.Requests.Factories.Commands.UpdateFactory
{
    internal sealed class UpdateFactoryCommandHandler : ICommandHandler<UpdateFactoryCommand, Factory>
    {
        private readonly IFactoryRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateFactoryCommandHandler(IFactoryRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Factory>> Handle(UpdateFactoryCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
            if (entity == null)
                return Result.Failure<Factory>(new Error(
                    $"No {nameof(Factory)} were found for Id {request.Id}"), HttpStatusCode.UnprocessableContent);
            entity.Update(request.name);

            _repository.Update(entity);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success(entity);
        }
    }
}
