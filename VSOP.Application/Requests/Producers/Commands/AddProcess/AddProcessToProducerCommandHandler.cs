using System.Net;
using VSOP.Application.Abstractions.Messaging;
using VSOP.Application.Data;
using VSOP.Domain.DbModels.Producers;
using VSOP.Domain.Primitives;
using VSOP.Domain.Primitives.Results;

namespace VSOP.Application.Requests.Producers.Commands.AddProcess
{
    internal sealed class AddProcessToProducerCommandHandler : ICommandHandler<AddProcessToProducerCommand, Producer>
    {
        private readonly IProducerRepository _producerRepository;
        private readonly IProcessRepository _processRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AddProcessToProducerCommandHandler(IProducerRepository producerRepository, IProcessRepository processRepository, IUnitOfWork unitOfWork)
        {
            _producerRepository = producerRepository;
            _processRepository = processRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Producer>> Handle(AddProcessToProducerCommand request, CancellationToken cancellationToken)
        {
            var producer = await _producerRepository.GetWithProcessesByIdAsync(request.producerId, cancellationToken);
            if (producer == null)
                return Result.Failure<Producer>(new Error($"{nameof(Producer)} was not found by Id - {request.producerId}"), HttpStatusCode.UnprocessableContent);

            var process = await _processRepository.GetByIdAsync(request.processId, cancellationToken);
            if (process == null)
                return Result.Failure<Producer>(new Error($"{nameof(Process)} was not found by Id - {request.processId}"), HttpStatusCode.UnprocessableContent);

            if (producer.Processes.Any(x => x.Id == process.Id))
                return Result.Failure<Producer>(new Error($"{nameof(Process)} is already linked to this {nameof(Producer)}."));

            producer.Processes.Add(process);

            _producerRepository.Update(producer);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success(producer);
        }
    }
}
