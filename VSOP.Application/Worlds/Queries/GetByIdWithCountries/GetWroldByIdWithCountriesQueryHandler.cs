using System.Net;
using VSOP.Application.Abstractions.Messaging;
using VSOP.Application.Data;
using VSOP.Domain.DbModels.Worlds;
using VSOP.Domain.Primitives;
using VSOP.Domain.Primitives.Results;
using VSOP.Persistence.Repositories;

namespace VSOP.Application.Worlds.Queries.GetById;

internal sealed class GetWorldByIdQueryHandler : IQueryHandler<GetWroldByIdWithCountriesQuery, World>
{
    private readonly IWorldRepository _worldRepository;

    public GetWorldByIdQueryHandler(IWorldRepository worldRepository)
    {
        _worldRepository = worldRepository;
    }

    public async Task<Result<World>> Handle(GetWroldByIdWithCountriesQuery request, CancellationToken cancellationToken)
    {
        var result = _worldRepository.GetWorldWithCountiesByIdAsync(request.Id);
        if (result is null || !result.Any())
            return Result.Failure<World>(new Error(
                HttpStatusCode.NoContent,
                $"No worlds were found by {request.Id}"));

        else if (result.Count() > 1)
            return Result.Failure<World>(new Error(
               HttpStatusCode.NoContent,
               $"More then one worlds were found by {request.Id}"));

        return Result.Success(result.First());
    }
}
