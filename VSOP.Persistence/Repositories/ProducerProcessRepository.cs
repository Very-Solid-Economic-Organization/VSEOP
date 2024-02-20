using VSOP.Domain.DbModels.Producers.ProducerProsesses;

namespace VSOP.Persistence.Repositories;

internal class ProducerProcessRepository : Repository<ProducerProcess>, IProducerProcessRepository
{
    public ProducerProcessRepository(VSEOPContext context) : base(context)
    {
    }
}