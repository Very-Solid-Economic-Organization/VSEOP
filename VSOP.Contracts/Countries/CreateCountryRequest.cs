namespace VSOP.Contracts.Countries;

public class CreateCountryRequest
{
    public Guid WorldId { get; set; }

    public string Name { get; set; }
}