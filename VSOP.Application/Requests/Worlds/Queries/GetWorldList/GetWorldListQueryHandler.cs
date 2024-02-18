using System.Net;
using VSOP.Application.Abstractions.Messaging;
using VSOP.Domain.DbModels.Worlds;
using VSOP.Domain.Primitives.Results;

namespace VSOP.Application.Requests.Worlds.Queries.GetWorldList;

internal sealed class GetWorldListQueryHandler : IQueryHandler<GetWorldListQuery, List<World>>
{
    private readonly IWorldRepository _repository;

    public GetWorldListQueryHandler(IWorldRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<List<World>>> Handle(GetWorldListQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<World> result;
        if (!string.IsNullOrWhiteSpace(request.name))
        {
            result = await _repository.WhereAsync(x => x.Name == request.name, cancellationToken);
        }
        else
        {
            result = await _repository.GetAllAsync(cancellationToken);
        }

        if (result?.Any() != true)
            return Result.Success<List<World>>(null, HttpStatusCode.NoContent);

        return Result.Success(result.ToList());
    }
}