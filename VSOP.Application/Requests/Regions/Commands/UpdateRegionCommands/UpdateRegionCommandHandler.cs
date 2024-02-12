using VSOP.Application.Abstractions.Messaging;
using VSOP.Application.Data;
using VSOP.Domain.DbModels.Regions;
using VSOP.Domain.Primitives.Results;

//namespace VSOP.Application.Requests.Regions.Commands.UpdateRegionCommands;

//internal sealed class UpdateRegionCommandHandler : ICommandHandler<UpdateRegionCommand, Region>
//{
//    private readonly IRegionRepository _repository;
//    private readonly IUnitOfWork _unitOfWork;

//    public UpdateRegionCommandHandler(IRegionRepository regionStoreRepository, IUnitOfWork unitOfWork)
//    {
//        _repository = regionStoreRepository;
//        _unitOfWork = unitOfWork;
//    }

//    public async Task<Result<Region>> Handle(UpdateRegionCommand request, CancellationToken cancellationToken)
//    {
//        var newRegionStore = Region.Create(request.regionId);

//        await _repository.AddAsync(newRegionStore, cancellationToken);

//        await _unitOfWork.SaveChangesAsync(cancellationToken);

//        return Result.Success(newRegionStore);
//    }
//}
