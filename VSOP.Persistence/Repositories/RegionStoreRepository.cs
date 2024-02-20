using Microsoft.EntityFrameworkCore;
using VSOP.Domain.DbModels.Regions.RegionStores;

namespace VSOP.Persistence.Repositories;

internal class RegionStoreRepository : Repository<RegionStore>, IRegionStoreRepository
{
    public RegionStoreRepository(VSEOPContext context) : base(context)
    {
    }

    /// <summary>
    /// Метод возвращает регион со списком всех относящихся к нему объектов потребления
    /// </summary>
    /// <param name="id">Id региона</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Объект региона со списком всех относящихся к нему объектов потребления или null</returns>
    public async Task<RegionStore?> GetWithCommoditiesByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Include(x => x.StoredCommodities).FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }
}