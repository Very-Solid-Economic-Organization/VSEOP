using System.Net;
using VSOP.Application.Abstractions.Messaging;
using VSOP.Application.Data;
using VSOP.Domain.DbModels.Processes;
using VSOP.Domain.Primitives;
using VSOP.Domain.Primitives.Results;

namespace VSOP.Application.Requests.Processes.Commands.UpdateProcess
{
    internal sealed class UpdateProcessCommandHandler : ICommandHandler<UpdateProcessCommand, Process>
    {
        private readonly IProcessRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateProcessCommandHandler(IProcessRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Process>> Handle(UpdateProcessCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
            if (entity == null)
                return Result.Failure<Process>(new Error(
                    $"No {nameof(Process)} were found for Id {request.Id}"), HttpStatusCode.UnprocessableContent);
            entity.Update(request.name, request.processTickrate);

            _repository.Update(entity);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success(entity);
        }
    }
}
