using System.ComponentModel.DataAnnotations;
using VSOP.Domain.DbModels.Comodities;
using VSOP.Domain.Primitives;

namespace VSOP.Domain.DbModels.Producers;

public class Process : Entity, IEquatable<Process>
{
    public Process(Guid id, Guid producerId, int processesCount) : base(id)
    {
        ProducerId = producerId;
        ProcessesCount = processesCount;
    }

    public int ProcessesCount { get; set; } = 0;

    public Guid ProducerId { get; private init; }

    public Producer Producer { get; private set; }

    public HashSet<ProcessedCommodity> ConsumingCommodities { get; set; } = new(); //TODO : не тот тип, переделать

    public HashSet<ProcessedCommodity> ProducedCommodities { get; set; } = new();

    public static Process Create(Guid producerId, int processesCount)
    {
        if (producerId == Guid.Empty)
            throw new ValidationException("Producer Id can't be empty");

        if (processesCount < 0)
            throw new ValidationException("ProcessesCount can't be negative");

        return new(Guid.NewGuid(), producerId, processesCount);
    }

    public bool Equals(Process? other)
    {
        return Id == other?.Id;
    }
}
