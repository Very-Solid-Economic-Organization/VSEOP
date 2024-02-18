using VSOP.Domain.DbModels.Producers;

namespace VSOP.Persistence.Repositories;

internal class ProcessedCommodityRepository : Repository<ProcessedCommodity>, IProcessedCommodityRepository
{
    public ProcessedCommodityRepository(VSEOPContext context) : base(context)
    {
    }
}