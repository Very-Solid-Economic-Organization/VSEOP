using System.Net;
using VSOP.Application.Abstractions.Messaging;
using VSOP.Domain.DbModels.Regions;
using VSOP.Domain.DbModels.Worlds;
using VSOP.Domain.Primitives;
using VSOP.Domain.Primitives.Results;

namespace VSOP.Application.Requests.Regions.Queries.GetRegionById;


internal sealed class GetRegionByIdQueryHandler : IQueryHandler<GetRegionByIdQuery, Region>
{
    private readonly IRegionRepository _repository;

    public GetRegionByIdQueryHandler(IRegionRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<Region>> Handle(GetRegionByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (result is null)
            return Result.Success(result, HttpStatusCode.NoContent);

        return Result.Success(result);
    }
}