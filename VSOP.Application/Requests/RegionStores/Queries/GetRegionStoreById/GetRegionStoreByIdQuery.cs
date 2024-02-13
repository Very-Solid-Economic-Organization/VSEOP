using VSOP.Application.Abstractions.Messaging;
using VSOP.Domain.DbModels.Regions;

namespace VSOP.Application.Requests.RegionStores.Queries.GetRegionStoreById
{
    public sealed record GetRegionStoreByIdQuery(Guid Id, bool IncludeCommodities = false) : IQuery<RegionStore>;
}
