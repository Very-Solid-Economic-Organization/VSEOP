using Microsoft.EntityFrameworkCore;
using VSOP.Domain.DbModels.Worlds;

namespace VSOP.Persistence.Repositories;

internal class WorldRepository : Repository<World>, IWorldRepository
{
    public WorldRepository(VSEOPContext context) : base(context)
    {
    }

    //public IEnumerable<World> Where(Guid id)
    //{
    //    return _context.Where(x => x.Id == id).Include(x => x.Countries);
    //}
}