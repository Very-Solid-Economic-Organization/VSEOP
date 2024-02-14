using System.Net;
using VSOP.Application.Abstractions.Messaging;
using VSOP.Application.Data;
using VSOP.Domain.DbModels.Regions;
using VSOP.Domain.DbModels.Worlds;
using VSOP.Domain.Primitives;
using VSOP.Domain.Primitives.Results;

namespace VSOP.Application.Requests.Regions.Commands.RemoveRegion;

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
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity is null)
            return Result.Failure(new Error($"{nameof(Region)} was not found by Id - {request.Id}"), HttpStatusCode.UnprocessableContent);

        _repository.Remove(entity);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
