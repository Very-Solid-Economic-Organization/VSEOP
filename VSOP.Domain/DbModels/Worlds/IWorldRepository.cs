using VSOP.Domain.DbModels.Worlds;

namespace VSOP.Persistence.Repositories;

public interface IWorldRepository
{
    public IEnumerable<World> GetWorldWithCountiesByIdAsync(Guid id);
}