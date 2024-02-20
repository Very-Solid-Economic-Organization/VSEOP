namespace VSOP.Contracts.Process;

public class CreateProcessRequest
{
    public string Name { get; set; }
    public ulong ProcessTickrate { get; set; }
}