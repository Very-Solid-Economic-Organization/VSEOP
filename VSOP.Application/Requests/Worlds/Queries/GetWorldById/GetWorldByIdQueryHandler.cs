using System.Net;
using VSOP.Application.Abstractions.Messaging;
using VSOP.Domain.DbModels.Worlds;
using VSOP.Domain.Primitives.Results;

namespace VSOP.Application.Requests.Worlds.Queries.GetWorldById;


internal sealed class GetWorldByIdQueryHandler : IQueryHandler<GetWorldByIdQuery, World>
{
    private readonly IWorldRepository _repository;

    public GetWorldByIdQueryHandler(IWorldRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<World>> Handle(GetWorldByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (result is null)
            return Result.Success(result, HttpStatusCode.NoContent);

        return Result.Success(result);
    }
}