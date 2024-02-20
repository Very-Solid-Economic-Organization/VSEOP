using System.Net;
using VSOP.Application.Abstractions.Messaging;
using VSOP.Domain.DbModels.Processes.ProcessedCommodities;
using VSOP.Domain.Primitives.Results;

namespace VSOP.Application.Requests.ProcessedCommodities.Queries.GetProcessedCommodityById;

internal sealed class GetProcessedCommodityByIdQueryHandler : IQueryHandler<GetProcessedCommodityByIdQuery, ProcessedCommodity>
{
    private readonly IProcessedCommodityRepository _Repository;

    public GetProcessedCommodityByIdQueryHandler(IProcessedCommodityRepository Repository)
    {
        _Repository = Repository;
    }

    public async Task<Result<ProcessedCommodity>> Handle(GetProcessedCommodityByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _Repository.GetByIdAsync(request.Id, cancellationToken);
        if (result is null)
            return Result.Success(result, HttpStatusCode.NoContent);

        return Result.Success(result);
    }
}
