namespace VSOP.Contracts.Worlds;

public class CreateWorldRequest
{
    public string Name { get; set; }

    public DateTime CurrentDateTime { get; set; }

    public DateTime BeginingOfTheTimeLine { get; set; }
}