using VSOP.Application.Abstractions.Messaging;
using VSOP.Application.Data;
using VSOP.Application.Requests.RegionStories.Commands.CreateRegionStoriesCommands;
using VSOP.Domain.DbModels.Regions;
using VSOP.Domain.Primitives.Results;

namespace VSOP.Application.Requests.Worlds.Commads.CreateWorld;

internal sealed class UpdateRegionCommandHandler : ICommandHandler<UpdateRegionCommand, Region>
{
    private readonly IRegionRepository _regionStoreRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateRegionCommandHandler(IRegionRepository regionStoreRepository, IUnitOfWork unitOfWork)
    {
        _regionStoreRepository = regionStoreRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Region>> Handle(UpdateRegionCommand request, CancellationToken cancellationToken)
    {
        var newRegionStore = Region.Create(request.na);

        await _regionStoreRepository.AddAsync(newRegionStore, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(newRegionStore);
    }
}
