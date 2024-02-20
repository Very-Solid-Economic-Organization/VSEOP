namespace VSOP.Contracts.Process;

public class UpdateProcessRequest
{
    public string Name { get; set; }

    public ulong ProcessTickrate { get; set; }
}