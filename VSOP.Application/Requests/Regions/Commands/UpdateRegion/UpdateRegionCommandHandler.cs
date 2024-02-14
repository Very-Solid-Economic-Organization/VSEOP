using System.Net;
using VSOP.Application.Abstractions.Messaging;
using VSOP.Application.Data;
using VSOP.Application.Requests.Worlds.Commads.UpdateWorld;
using VSOP.Domain.DbModels.Regions;
using VSOP.Domain.DbModels.Worlds;
using VSOP.Domain.Primitives;
using VSOP.Domain.Primitives.Results;

namespace VSOP.Application.Requests.Regions.Commands.UpdateRegion;

internal sealed class UpdateRegionCommandHandler : ICommandHandler<UpdateRegionCommand, Region>
{
    private readonly IRegionRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateRegionCommandHandler(IRegionRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Region>> Handle(UpdateRegionCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null)
            return Result.Failure<Region>(new Error($"{nameof(Region)} was not found by Id - {request.Id}"), HttpStatusCode.UnprocessableContent);

        entity.Update(request.name);

        _repository.Update(entity);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(entity);
    }
}
