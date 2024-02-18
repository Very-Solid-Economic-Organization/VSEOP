using System.Net;
using VSOP.Application.Abstractions.Messaging;
using VSOP.Application.Data;
using VSOP.Domain.DbModels.Factories;
using VSOP.Domain.DbModels.Regions;
using VSOP.Domain.Primitives;
using VSOP.Domain.Primitives.Results;

namespace VSOP.Application.Requests.Factories.Commands.CreateFactory
{
    internal sealed class CreateFactoryCommandHandler : ICommandHandler<CreateFactoryCommand, Factory>
    {
        private readonly IFactoryRepository _factoryRepository;
        private readonly IRegionRepository _regionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateFactoryCommandHandler(IFactoryRepository factoryRepository, IRegionRepository regionRepository, IUnitOfWork unitOfWork)
        {
            _factoryRepository = factoryRepository;
            _regionRepository = regionRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Factory>> Handle(CreateFactoryCommand request, CancellationToken cancellationToken)
        {
            if (!await _regionRepository.AnyAsync(x => x.Id == request.RegionId, cancellationToken))
                return Result.Failure<Factory>(new Error($"{nameof(Region)} was not found by Id - {request.RegionId}"), HttpStatusCode.UnprocessableContent);

            var entity = Factory.Create(request.RegionId, request.name);

            await _factoryRepository.AddAsync(entity, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success(entity);
        }
    }
}
