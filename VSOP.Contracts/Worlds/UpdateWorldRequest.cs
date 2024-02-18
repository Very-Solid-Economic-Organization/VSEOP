namespace VSOP.Contracts.Worlds;

public class UpdateWorldRequest
{
    public string? Name { get; set; }

    public DateTime? CurrentDateTime { get; set; }

    public DateTime? BeginingOfTheTimeLine { get; set; }
}