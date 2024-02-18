using System.Net;
using VSOP.Application.Abstractions.Messaging;
using VSOP.Domain.DbModels.Commodities;
using VSOP.Domain.Primitives.Results;

namespace VSOP.Application.Requests.Commodities.Queries.GetCommodityById;

internal sealed class GetCommodityByIdQueryHandler : IQueryHandler<GetCommodityByIdQuery, Commodity>
{
    private readonly ICommodityRepository _repository;

    public GetCommodityByIdQueryHandler(ICommodityRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<Commodity>> Handle(GetCommodityByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (result is null)
            return Result.Success(result, HttpStatusCode.NoContent);

        return Result.Success(result);
    }
}
