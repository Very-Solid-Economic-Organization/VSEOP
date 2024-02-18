using VSOP.Domain.DbModels.Regions;

namespace VSOP.Persistence.Repositories;

internal class RegionRepository : Repository<Region>, IRegionRepository
{
    public RegionRepository(VSEOPContext context) : base(context)
    {
    }

    //public IEnumerable<World> Where(Guid id)
    //{
    //    return _context.Where(x => x.Id == id).Include(x => x.Countries);
    //}
}