using VSOP.Domain.Primitives;

namespace VSOP.Domain.DbModels.Producers;

public abstract class Producer : Entity, IEquatable<Producer>
{
    public Producer(Guid id, Guid regionId) : base(id)
    {
        RegionId = regionId;
    }

    public Guid RegionId { get; private init; }

    public List<Process> Processes { get; private init; } = new();

    public bool Equals(Producer? other)
    {
        return Id == other?.Id;
    }
}