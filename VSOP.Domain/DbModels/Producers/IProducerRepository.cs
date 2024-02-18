using VSOP.Domain.Primitives;

namespace VSOP.Domain.DbModels.Producers;

public interface IProducerRepository : IRepository<Producer>
{
    public Task<Producer?> GetWithProcessesByIdAsync(Guid id, CancellationToken cancellationToken);
    public Task<List<Producer>> GetAllWithProcessesAsync(CancellationToken cancellationToken);
}