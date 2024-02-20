using VSOP.Domain.DbModels.Processes.ProcessedCommodities;

namespace VSOP.Persistence.Repositories;

internal class ProcessedCommodityRepository : Repository<ProcessedCommodity>, IProcessedCommodityRepository
{
    public ProcessedCommodityRepository(VSEOPContext context) : base(context)
    {
    }
}