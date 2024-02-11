using System.ComponentModel.DataAnnotations;
using VSOP.Domain.DbModels.Comodities;
using VSOP.Domain.Primitives;

namespace VSOP.Domain.DbModels.Producers;

public class Process : Entity, IEquatable<Process>
{
    public Process(Guid id, Guid factoryId, int processesCount) : base(id)
    {
        FactoryId = factoryId;
        ProcessesCount = processesCount;
    }

    public int ProcessesCount { get; set; } = 0;

    public Guid FactoryId { get; private init; }

    public List<Commodity> ConsumingCommodities { get; set; } = new();

    public List<Commodity> ProducedCommodities { get; set; } = new();

    public static Process Create(Guid factoryId, int processesCount)
    {
        if (factoryId == Guid.Empty)
            throw new ValidationException("Factory Id can't be empty");

        if (processesCount < 0)
            throw new ValidationException("ProcessesCount can't be negative");

        return new(Guid.NewGuid(), factoryId, processesCount);
    }

    public bool Equals(Process? other)
    {
        return Id == other?.Id;
    }
}
