using VSOP.Application.Abstractions.Messaging;
using VSOP.Domain.DbModels.Regions;

namespace VSOP.Application.Requests.Regions.Queries.GetRegionById
{
    public sealed record GetRegionByIdQuery(Guid Id) : IQuery<Region>;
}
