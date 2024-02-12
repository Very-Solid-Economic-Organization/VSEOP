using VSOP.Application.Abstractions.Messaging;
using VSOP.Domain.DbModels.Regions;

namespace VSOP.Application.Requests.RegionStories.Queries.GetRegionStoreById
{
    public sealed record GetRegionStoreByIdQuery(Guid Id) : IQuery<RegionStore>;
}
