using System.Net;
using VSOP.Application.Abstractions.Messaging;
using VSOP.Application.Data;
using VSOP.Domain.DbModels.Worlds;
using VSOP.Domain.Primitives;
using VSOP.Domain.Primitives.Results;

namespace VSOP.Application.Requests.Worlds.Commads.RemoveWorld;

internal sealed class RemoveWorldCommandHandler : ICommandHandler<RemoveWorldCommand>
{
    private readonly IWorldRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public RemoveWorldCommandHandler(IWorldRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(RemoveWorldCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity is null)
            return Result.Failure<World>(new Error($"{nameof(World)} was not found by Id - {request.Id}"), HttpStatusCode.UnprocessableContent);

        _repository.Remove(entity);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(HttpStatusCode.NoContent);
    }
}