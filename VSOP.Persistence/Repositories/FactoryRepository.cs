using VSOP.Domain.DbModels.Factories;

namespace VSOP.Persistence.Repositories;

internal class FactoryRepository : Repository<Factory>, IFactoryRepository
{
    public FactoryRepository(VSEOPContext context) : base(context)
    {
    }
}