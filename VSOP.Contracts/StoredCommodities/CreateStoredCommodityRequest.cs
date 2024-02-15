namespace VSOP.Contracts.StoredCommodities;

public class CreateStoredCommodityRequest
{
    public Guid CommodityId { get; init; }

    public float Quantity { get; init; }

    public ulong SelfCost { get; set; }

    public ulong Price { get; set; }

    public int CurrentDemand { get; set; }
}