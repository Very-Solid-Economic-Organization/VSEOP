using VSOP.Domain.DbModels.Producers;

namespace VSOP.Persistence.Repositories;

internal class ProcessRepository : Repository<Process>, IProcessRepository
{
    public ProcessRepository(VSEOPContext context) : base(context)
    {
    }
}