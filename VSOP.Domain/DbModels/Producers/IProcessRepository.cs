using VSOP.Domain.Primitives;

namespace VSOP.Domain.DbModels.Producers;

public interface IProcessRepository : IRepository<Process>
{
    public Task<Process?> GetWithCommoditiesByIdAsync(Guid id, CancellationToken cancellationToken);
}