using VSOP.Domain.DbModels.Worlds;

namespace VSOP.Persistence.Repositories
{
    internal interface IWorldRepository
    {
        IEnumerable<World> GetWorldWithCountiesByIdAsync(Guid id);
    }
}