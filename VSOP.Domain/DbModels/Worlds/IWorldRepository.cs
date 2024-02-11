using System.Net.Sockets;
using VSOP.Domain.DbModels.Worlds;
using VSOP.Domain.Primitives;

namespace VSOP.Persistence.Repositories;

public interface IWorldRepository : IRepository<World>
{
    public IEnumerable<World> GetWorldWithCountiesByIdAsync(Guid id);
}