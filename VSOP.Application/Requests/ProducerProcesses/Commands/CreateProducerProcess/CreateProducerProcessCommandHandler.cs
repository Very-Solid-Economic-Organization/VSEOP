using System.Net;
using VSOP.Application.Abstractions.Messaging;
using VSOP.Application.Data;
using VSOP.Domain.DbModels.Processes;
using VSOP.Domain.DbModels.Producers;
using VSOP.Domain.DbModels.Producers.ProducerProsesses;
using VSOP.Domain.Primitives;
using VSOP.Domain.Primitives.Results;

namespace VSOP.Application.Requests.ProducerProcesses.Commands.CreateProducerProcess
{
    internal sealed class CreateProducerProcessCommandHandler : ICommandHandler<CreateProducerProcessCommand, ProducerProcess>
    {
        private readonly IProducerRepository _producerRepository;
        private readonly IProducerProcessRepository _producerProcessRepository;
        private readonly IProcessRepository _processRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateProducerProcessCommandHandler(
            IProducerRepository producerRepository,
            IProducerProcessRepository producerProcessRepository,
            IProcessRepository processRepository,
            IUnitOfWork unitOfWork)
        {
            _producerRepository = producerRepository;
            _producerProcessRepository = producerProcessRepository;
            _processRepository = processRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<ProducerProcess>> Handle(CreateProducerProcessCommand request, CancellationToken cancellationToken)
        {
            if (await _producerProcessRepository.AnyAsync(x => x.ProcessId == request.processId && x.ProducerId == request.producerId, cancellationToken))
                return Result.Failure<ProducerProcess>(
                    new Error($"{nameof(ProducerProcess)} with same parameters already exists"));

            var producer = await _producerRepository.GetWithProcessesByIdAsync(request.producerId, cancellationToken);
            if (producer == null)
                return Result.Failure<ProducerProcess>(
                    new Error($"{nameof(Producer)} was not found by Id - {request.producerId}"), HttpStatusCode.UnprocessableContent);

            var process = await _processRepository.GetByIdAsync(request.processId, cancellationToken);
            if (process == null)
                return Result.Failure<ProducerProcess>(
                    new Error($"{nameof(Process)} was not found by Id - {request.processId}"), HttpStatusCode.UnprocessableContent);

            var prodProcess = ProducerProcess.Create(request.producerId, request.processId, request.ProcessesCount);

            producer.ProdProcesses.Add(prodProcess);

            _producerProcessRepository.Update(prodProcess);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success(prodProcess);
        }
    }
}
