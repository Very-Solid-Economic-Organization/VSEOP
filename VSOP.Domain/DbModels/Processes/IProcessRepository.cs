using VSOP.Domain.Primitives;

namespace VSOP.Domain.DbModels.Processes;

public interface IProcessRepository : IRepository<Process>
{
    public Task<Process?> GetWithCommoditiesByIdAsync(Guid id, CancellationToken cancellationToken);
}