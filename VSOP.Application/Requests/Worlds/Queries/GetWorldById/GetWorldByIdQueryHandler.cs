using System.Net;
using VSOP.Application.Abstractions.Messaging;
using VSOP.Domain.DbModels.Worlds;
using VSOP.Domain.Primitives;
using VSOP.Domain.Primitives.Results;

namespace VSOP.Application.Requests.Worlds.Queries.GetWorldById;


internal sealed class GetWorldByIdQueryHandler : IQueryHandler<GetWorldByIdQuery, World>
{
    private readonly IWorldRepository _worldRepository;

    public GetWorldByIdQueryHandler(IWorldRepository worldRepository)
    {
        _worldRepository = worldRepository;
    }

    public async Task<Result<World>> Handle(GetWorldByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _worldRepository.GetByIdAsync(request.Id, cancellationToken);
        if (result is null)
            return Result.Failure<World>(new Error(
                HttpStatusCode.NoContent, //TODO: Подумать над HTMLStatusCode подходящим для ситуации
                $"No worlds were found by Id {request.Id}"));

        return Result.Success<World>(result);
    }
}