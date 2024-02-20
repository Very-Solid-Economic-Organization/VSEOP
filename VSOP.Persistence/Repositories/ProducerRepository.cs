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
        return await _context.Include(x => x.ProdProcesses).FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }
    public async Task<List<Producer>> GetAllWithProcessesAsync(CancellationToken cancellationToken)
    {
        return await _context.Include(x => x.ProdProcesses).AsNoTracking().ToListAsync(cancellationToken);
    }
}