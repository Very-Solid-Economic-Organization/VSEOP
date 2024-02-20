using Microsoft.EntityFrameworkCore;
using VSOP.Domain.DbModels.Producers;
using VSOP.Domain.DbModels.Regions;

namespace VSOP.Persistence.Repositories;

internal class ProducerProcessRepository : Repository<ProducerProcess>, IProducerProcessRepository
{
    public ProducerProcessRepository(VSEOPContext context) : base(context)
    {
    }
}