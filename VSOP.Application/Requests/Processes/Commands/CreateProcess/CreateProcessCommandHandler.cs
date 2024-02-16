using VSOP.Application.Abstractions.Messaging;
using VSOP.Application.Data;
using VSOP.Domain.DbModels.Producers;
using VSOP.Domain.Primitives.Results;

namespace VSOP.Application.Requests.Commodities.Commands.CreateCommodity
{
    internal sealed class CreateProcessCommandHandler : ICommandHandler<CreateProcessCommand, Process>
    {
        private readonly IProcessRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateProcessCommandHandler(IProcessRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Process>> Handle(CreateProcessCommand request, CancellationToken cancellationToken)
        {
            //if (!await _worldRepository.AnyAsync(x => x.Id == request.WorldId, cancellationToken))
            //    return Result.Failure<Commodity>(new Error($"{nameof(World)} was not found by Id - {request.WorldId}"), HttpStatusCode.UnprocessableContent);

            var entity = Process.Create(request.processesCount, request.name);

            await _repository.AddAsync(entity, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success(entity);
        }
    }
}
