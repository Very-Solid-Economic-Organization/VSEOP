using Microsoft.EntityFrameworkCore;
using VSOP.Domain.DbModels.Regions;
using VSOP.Domain.DbModels.Worlds;
using VSOP.Domain.Primitives;

namespace VSOP.Persistence.Repositories;

internal class RegionStoreRepository : Repository<RegionStore>, IRegionStoreRepository
{
    public RegionStoreRepository(VSEOPContext context) : base(context)
    {
    }


    public async Task<RegionStore?> GetWithCommoditiesByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Include(x => x.StoredCommodities).FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }
}