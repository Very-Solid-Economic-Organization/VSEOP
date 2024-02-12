using FluentValidation;
using System.Net;
using VSOP.Application.Abstractions.Messaging;
using VSOP.Domain.DbModels.Worlds;
using VSOP.Domain.Primitives;
using VSOP.Domain.Primitives.Results;

namespace VSOP.Application.Requests.Worlds.Queries.GetWorldList;

internal sealed class GetWorldListQueryHandler : IQueryHandler<GetWorldListQuery, List<World>>
{
    private readonly IWorldRepository _Repository;

    public GetWorldListQueryHandler(IWorldRepository Repository)
    {
        _Repository = Repository;
    }

    public async Task<Result<List<World>>> Handle(GetWorldListQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<World> result;
        if (!string.IsNullOrWhiteSpace(request.name))
        {
            result = await _Repository.GetAllAsync(x => x.Name == request.name, cancellationToken);
        }
        else
        {
            result = await _Repository.GetAllAsync(cancellationToken);
        }

        if (result?.Any() != true)
            return Result.Failure<List<World>>(new Error(
                HttpStatusCode.NoContent,
                $"Not found any objects of world"));

        return Result.Success(result as List<World>);
    }
}
