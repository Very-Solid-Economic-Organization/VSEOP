using VSOP.Domain.DbModels.Regions.StoredCommodities;

namespace VSOP.Persistence.Repositories;

internal class StoredCommodityRepository : Repository<StoredCommodity>, IStoredCommodityRepository
{
    public StoredCommodityRepository(VSEOPContext context) : base(context)
    {
    }
}