namespace VSOP.Contracts.Commodities;

public class CreateCommodityRequest
{
    public Guid WorldId { get; set; }

    public string Name { get; set; }
}