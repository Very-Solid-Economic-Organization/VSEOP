using VSOP.Domain.DbModels.Factories;
using VSOP.Domain.DbModels.Producers;

namespace VSOP.Persistence.Repositories;

internal class ProducerRepository : Repository<Producer>, IProducerRepository
{
    public ProducerRepository(VSEOPContext context) : base(context)
    {
    }
}