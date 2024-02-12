using Microsoft.EntityFrameworkCore;
using VSOP.Domain.DbModels.Worlds;

namespace VSOP.Persistence.Repositories;

internal class WorldRepository : Repository<World>, IWorldRepository
{
    public WorldRepository(DbContext context) : base(context)
    {
    }

    public IEnumerable<World> GetWorldWithCountiesByIdAsync(Guid id) //TODO: To delete
    {
        return _context.Where(x => x.Id == id).Include(x => x.Countries);
    }
}