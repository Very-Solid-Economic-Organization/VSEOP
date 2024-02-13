using VSOP.Domain.DbModels.Regions;
using VSOP.Domain.Primitives;

namespace VSOP.Domain.DbModels.Producers;

public abstract class Producer : Entity, IEquatable<Producer>
{
    protected Producer(Guid id, Guid regionId, string name) : base(id)
    {
        RegionId = regionId;
        Name = name;
    }

    public string Name { get; private set; }

    public Guid RegionId { get; private init; }

    public Region Region { get; private set; }

    public List<Process> Processes { get; private init; } = new();

    public bool Equals(Producer? other)
    {
        return Id == other?.Id;
    }
}