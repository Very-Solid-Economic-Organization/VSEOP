using System.ComponentModel.DataAnnotations;
using VSOP.Models.DbModels.Countries;
using VSOP.Models.DbModels.Regions;
using VSOP.Models.Primitives;

namespace VSOP.Models.DbModels.Worlds;

public class World : Entity
{
    private World(Guid id, string name /*, Guid masterId*/) : base(id)
    {
        Name = name;
        //MasterId = masterId;
    }

    public string Name { get; private set; }

    //public Guid MasterId { get; private init; }

    public HashSet<Country> Countries { get; private set; }

    public static World Create(string name, Guid masterId)
    {
        if (string.IsNullOrEmpty(name))
            throw new ValidationException("Name property can't be null or empty");

        if (masterId == Guid.Empty)
            throw new ValidationException("Game master Id can't be empty");

        return new World(Guid.NewGuid(), name/*, masterId*/);
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