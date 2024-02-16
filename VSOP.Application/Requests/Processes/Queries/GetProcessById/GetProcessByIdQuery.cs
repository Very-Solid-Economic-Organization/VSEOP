using VSOP.Application.Abstractions.Messaging;
using VSOP.Domain.DbModels.Commodities;
using VSOP.Domain.DbModels.Producers;

namespace VSOP.Application.Requests.Commodities.Queries.GetCommodityById
{
    public sealed record GetProcessByIdQuery(Guid Id) : IQuery<Process>;

}
