using VSOP.Models.DbModels.Worlds;

namespace VSOP.Persistence.Repositories
{
    internal interface IWorldRepository
    {
        IEnumerable<World> GetWorldWithCountiesByIdAsync(Guid id);
    }
}