using System.Net;
using VSOP.Application.Abstractions.Messaging;
using VSOP.Application.Data;
using VSOP.Domain.DbModels.Producers.ProducerProsesses;
using VSOP.Domain.Primitives;
using VSOP.Domain.Primitives.Results;

namespace VSOP.Application.Requests.ProducerProcesses.Commands.RemoveProducerProcess
{
    internal sealed class RemoveProducerProcessCommandHandler : ICommandHandler<RemoveProducerProcessCommand>
    {
        private readonly IProducerProcessRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public RemoveProducerProcessCommandHandler(
            IProducerProcessRepository repository,
            IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(RemoveProducerProcessCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
            if (entity == null)
                return Result.Failure<ProducerProcess>(
                    new Error($"{nameof(ProducerProcess)} was not found by Id - {request.Id}"), HttpStatusCode.UnprocessableContent);

            _repository.Remove(entity);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
