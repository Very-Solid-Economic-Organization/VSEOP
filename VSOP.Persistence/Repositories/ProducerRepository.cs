using Microsoft.EntityFrameworkCore;
using VSOP.Domain.DbModels.Producers;

namespace VSOP.Persistence.Repositories;

internal class ProducerRepository : Repository<Producer>, IProducerRepository
{
    public ProducerRepository(VSEOPContext context) : base(context)
    {
    }

    public async Task<Producer?> GetWithProcessesByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Include(x => x.ProducerProcesses).FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }
    public async Task<List<Producer>> GetAllWithProcessesAsync(CancellationToken cancellationToken)
    {
        return await _context.Include(x => x.ProducerProcesses).AsNoTracking().ToListAsync(cancellationToken);
    }
}