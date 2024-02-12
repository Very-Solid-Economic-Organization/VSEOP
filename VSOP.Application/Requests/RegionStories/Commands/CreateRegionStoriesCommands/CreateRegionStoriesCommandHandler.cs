using VSOP.Application.Abstractions.Messaging;
using VSOP.Application.Data;
using VSOP.Application.Requests.RegionStories.Commands.CreateRegionStoriesCommands;
using VSOP.Domain.DbModels.Regions;
using VSOP.Domain.DbModels.Worlds;
using VSOP.Domain.Primitives.Results;

namespace VSOP.Application.Requests.Worlds.Commads.CreateWorld;

internal sealed class CreateRegionStoriesCommandHandler : ICommandHandler<CreateRegionStoriesCommand, RegionStore>
{
    private readonly IRegionStoreRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateRegionStoriesCommandHandler(IRegionStoreRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<RegionStore>> Handle(CreateRegionStoriesCommand request, CancellationToken cancellationToken)
    {
        var newRegionStore = RegionStore.Create(request.regionId);
        
        await _repository.AddAsync(newRegionStore, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(newRegionStore);
    }
}
