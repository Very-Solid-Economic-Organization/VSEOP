using VSOP.Application.Abstractions.Messaging;
using VSOP.Application.Data;
using VSOP.Domain.DbModels.Worlds;
using VSOP.Domain.Primitives.Results;

namespace VSOP.Application.Requests.Worlds.Commads.CreateWorld;

internal sealed class CreateWorldCommandHandler : ICommandHandler<CreateWorldCommand, World>
{
    private readonly IWorldRepository _worldRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateWorldCommandHandler(IWorldRepository worldRepository, IUnitOfWork unitOfWork)
    {
        _worldRepository = worldRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<World>> Handle(CreateWorldCommand request, CancellationToken cancellationToken)
    {
        var newWorld = World.Create(request.name);
        
        await _worldRepository.AddAsync(newWorld, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(newWorld);
    }
}
