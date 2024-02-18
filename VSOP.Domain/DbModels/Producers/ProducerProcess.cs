namespace VSOP.Domain.DbModels.Producers;

public class ProducerProcess
{
    public Guid ProducerId { get; private set; }
    public Producer Producer { get; set; }

    public Guid ProcessId { get; private set; }
    public Process Process { get; set; }

    public DateTime LastExecutionDateTime { get; set; }
}