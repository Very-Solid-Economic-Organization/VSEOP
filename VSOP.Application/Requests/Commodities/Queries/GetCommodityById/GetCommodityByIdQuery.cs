using VSOP.Application.Abstractions.Messaging;
using VSOP.Domain.DbModels.Commodities;
using VSOP.Domain.DbModels.Countries;

namespace VSOP.Application.Requests.Commodities.Queries.GetCommodityById
{
    public sealed record GetCommodityByIdQuery(Guid Id) : IQuery<Commodity>;

}
