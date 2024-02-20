using VSOP.Domain.Primitives;

namespace VSOP.Domain.DbModels.Regions.RegionStores
{
    public interface IRegionStoreRepository : IRepository<RegionStore>
    {
        public Task<RegionStore?> GetWithCommoditiesByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
