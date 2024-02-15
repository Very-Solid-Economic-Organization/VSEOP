namespace VSOP.Contracts.Regions;

public class CreateRegionRequest
{
    public Guid CountryId { get; set; }

    public string Name { get; set; }
}