using System.ComponentModel.DataAnnotations;
using VSOP.Domain.DbModels.Commodities;
using VSOP.Domain.DbModels.Countries;
using VSOP.Domain.Primitives;

namespace VSOP.Domain.DbModels.Worlds;

public class World : Entity
{
    private World(Guid id, string name/*, Guid masterId*/) : base(id)
    {
        Name = name;
        //MasterId = masterId;
    }

    public string Name { get; private set; }

    //public Guid MasterId { get; private init; } //TODO: implement

    public HashSet<Country> Countries { get; private set; } = new();

    public HashSet<Commodity> Commodities { get; private set; } = new();

    public static World Create(string name/*, Guid masterId*/)
    {
        if (string.IsNullOrEmpty(name))
            throw new ValidationException("Name property can't be null or empty");

        //if (masterId == Guid.Empty)
        //    throw new ValidationException("Game master Id can't be empty");

        return new World(Guid.NewGuid(), name/*, masterId*/);
    }

    //public World UpdateName(string name/*, Guid masterId*/)
    //{
    //    if (string.IsNullOrEmpty(name))
    //        throw new ValidationException("Name property can't be null or empty");

    //    Name = name;

    //    //if (masterId == Guid.Empty)
    //    //    throw new ValidationException("Game master Id can't be empty");

    //    return new World(Guid.NewGuid(), name/*, masterId*/);
    //}

    public bool Equals(Country? other)
    {
        return Id == other?.Id;
    }
}