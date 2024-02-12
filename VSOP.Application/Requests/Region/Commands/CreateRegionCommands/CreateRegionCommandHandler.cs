using VSOP.Application.Abstractions.Messaging;
using VSOP.Application.Data;
using VSOP.Application.Requests.RegionStories.Commands.CreateRegionStoriesCommands;
using VSOP.Domain.DbModels.Regions;
using VSOP.Domain.DbModels.Worlds;
using VSOP.Domain.Primitives.Results;

namespace VSOP.Application.Requests.Worlds.Commads.CreateWorld;

internal sealed class CreateRegionCommandHandler : ICommandHandler<CreateRegionCommand, Region>
{
    private readonly IRegionRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateRegionCommandHandler(IRegionRepository regionStoreRepository, IUnitOfWork unitOfWork)
    {
        _repository = regionStoreRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Region>> Handle(CreateRegionCommand request, CancellationToken cancellationToken)
    {
        var newRegion = Region.Create(request.name, request.countryId, request.regionStoreId);
        
        await _repository.AddAsync(newRegion, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(newRegion);
    }
}
