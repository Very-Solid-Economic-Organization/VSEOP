using VSOP.Models.DbModels.Regions;
using VSOP.Models.Primitives;

namespace VSOP.Models.DbModels.Countries;

public class Country : Entity, IEquatable<Country>
{
    public Country(Guid id, string name, Guid worldId) : base(id)
    {
        Name = name;
        WorldId = worldId;
    }

    public string Name { get; set; }

    public Guid WorldId { get; private init; }

    public HashSet<Region> Regions { get; private set; } = [];

    public static Country Create(string name, Guid worldId)
    {
        return new(Guid.NewGuid(), name, worldId);
    }

    public bool Equals(Country? other)
    {
        return Id == other?.Id;
    }

    public override bool Equals(object? otherObj)
    {
        return otherObj is Country other && Id == other.Id;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    public override string ToString()
    {
        return $"{Id} | {Name}";
    }
}