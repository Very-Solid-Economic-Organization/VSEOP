using System.ComponentModel.DataAnnotations;
using VSOP.Domain.DbModels.Processes;
using VSOP.Domain.Primitives;

namespace VSOP.Domain.DbModels.Producers.ProducerProsesses;

public class ProducerProcess : Entity
{
    public ProducerProcess(Guid id, Guid producerId, Guid processId, uint processesCount) : base(id) //TODO: мб переименовать
    {
        ProducerId = producerId;
        ProcessId = processId;
        ProcessesCount = processesCount;
    }

    public Guid ProducerId { get; private set; }
    public Producer Producer { get; set; }

    public Guid ProcessId { get; private set; }
    public Process Process { get; set; }

    /// <summary>Кол-во одновременно запущенных процессов данного типа</summary>
    public uint ProcessesCount { get; private set; } = 0;

    public DateTime LastExecutionDateTime { get; set; }

    public static ProducerProcess Create(Guid producerId, Guid processId, uint processesCount)
    {
        if (producerId == Guid.Empty)
            throw new ValidationException("ProducerId property can't be empty");

        if (processId == Guid.Empty)
            throw new ValidationException("ProcessId property can't be empty");

        return new ProducerProcess(Guid.NewGuid(), producerId, processId, processesCount);
    }

    public void Update(uint processesCount)
    {
        ProcessesCount = processesCount;
    }
}