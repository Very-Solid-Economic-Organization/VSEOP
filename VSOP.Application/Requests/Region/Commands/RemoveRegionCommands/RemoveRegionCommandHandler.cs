using System.Net;
using VSOP.Application.Abstractions.Messaging;
using VSOP.Application.Data;
using VSOP.Application.Requests.RegionStories.Commands.CreateRegionStoriesCommands;
using VSOP.Domain.DbModels.Regions;
using VSOP.Domain.Primitives;
using VSOP.Domain.Primitives.Results;

namespace VSOP.Application.Requests.Worlds.Commads.CreateWorld;

internal sealed class RemoveRegionCommandHandler : ICommandHandler<RemoveRegionCommand>
{
    private readonly IRegionRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public RemoveRegionCommandHandler(IRegionRepository regionStoreRepository, IUnitOfWork unitOfWork)
    {
        _repository = regionStoreRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(RemoveRegionCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.toRemove, cancellationToken);
        if (entity is null)
            return Result.Failure(new Error(
            HttpStatusCode.NoContent, //TODO: Подумать над HTMLStatusCode подходящим для ситуации
            $"No {nameof(Region)} were found for Id {request.toRemove}"));

        _repository.Remove(entity);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
