using Microsoft.EntityFrameworkCore;
using VSOP.Domain.DbModels.Regions;
using VSOP.Domain.DbModels.Worlds;
using VSOP.Domain.Primitives;

namespace VSOP.Persistence.Repositories;

internal class StoredCommodityRepository : Repository<StoredCommodity>, IStoredCommodityRepository
{
    public StoredCommodityRepository(VSEOPContext context) : base(context)
    {
    }
}