using VSOP.Domain.DbModels.Commodities;

namespace VSOP.Persistence.Repositories;

internal class CommodityRepository : Repository<Commodity>, ICommodityRepository
{
    public CommodityRepository(VSEOPContext context) : base(context)
    {
    }
}