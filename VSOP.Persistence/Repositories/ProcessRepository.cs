using Microsoft.EntityFrameworkCore;
using VSOP.Domain.DbModels.Processes;

namespace VSOP.Persistence.Repositories;

internal class ProcessRepository : Repository<Process>, IProcessRepository
{
    public ProcessRepository(VSEOPContext context) : base(context)
    {
    }
    public async Task<Process?> GetWithCommoditiesByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Include(x => x.CosumedCommdities).Include(x => x.ProcessedCommodities).FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }
}