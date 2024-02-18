namespace VSOP.Contracts.StoredCommodities;

public class UpdateStoredCommoditiesRequest
{
    public float? Quantity { get; set; }

    public ulong? SelfCost { get; set; }

    public ulong? Price { get; set; }

    public int? CurrentDemand { get; set; }
}