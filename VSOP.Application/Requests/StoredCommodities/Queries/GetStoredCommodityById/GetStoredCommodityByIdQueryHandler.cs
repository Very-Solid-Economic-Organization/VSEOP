using System.Net;
using VSOP.Application.Abstractions.Messaging;
using VSOP.Domain.DbModels.Regions.StoredCommodities;
using VSOP.Domain.Primitives.Results;

namespace VSOP.Application.Requests.StoredCommodities.Queries.GetStoredCommodityById;

internal sealed class GetStoredCommodityByIdQueryHandler : IQueryHandler<GetStoredCommodityByIdQuery, StoredCommodity>
{
    private readonly IStoredCommodityRepository _Repository;

    public GetStoredCommodityByIdQueryHandler(IStoredCommodityRepository Repository)
    {
        _Repository = Repository;
    }

    public async Task<Result<StoredCommodity>> Handle(GetStoredCommodityByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _Repository.GetByIdAsync(request.Id, cancellationToken);
        if (result is null)
            return Result.Success(result, HttpStatusCode.NoContent);

        return Result.Success(result);
    }
}
