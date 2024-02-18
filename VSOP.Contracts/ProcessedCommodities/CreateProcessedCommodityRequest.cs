namespace VSOP.Contracts.ProcessedCommodities;

public class CreateProcessedCommodityRequest
{
    public Guid ProcessId { get; set; }

    public Guid CommodityId { get; set; }

    public int Type { get; set; }

    public float Quantity { get; set; }
}