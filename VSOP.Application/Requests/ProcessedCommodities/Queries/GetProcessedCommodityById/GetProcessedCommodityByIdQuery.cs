using VSOP.Application.Abstractions.Messaging;
using VSOP.Domain.DbModels.Producers;

namespace VSOP.Application.Requests.ProcessedCommodities.Queries.GetProcessedCommodityById
{
    public sealed record GetProcessedCommodityByIdQuery(Guid Id) : IQuery<ProcessedCommodity>;

}
