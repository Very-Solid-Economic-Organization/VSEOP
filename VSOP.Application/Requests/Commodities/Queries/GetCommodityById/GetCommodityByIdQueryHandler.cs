using System.Net;
using VSOP.Application.Abstractions.Messaging;
using VSOP.Domain.DbModels.Commodities;
using VSOP.Domain.Primitives.Results;

namespace VSOP.Application.Requests.Commodities.Queries.GetCommodityById;

internal sealed class GetCommodityByIdQueryHandler : IQueryHandler<GetCommodityByIdQuery, Commodity>
{
    private readonly ICommodityRepository _Repository;

    public GetCommodityByIdQueryHandler(ICommodityRepository Repository)
    {
        _Repository = Repository;
    }

    public async Task<Result<Commodity>> Handle(GetCommodityByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _Repository.GetByIdAsync(request.Id, cancellationToken);
        if (result is null)
            return Result.Success(result, HttpStatusCode.NoContent);

        return Result.Success(result);
    }
}
