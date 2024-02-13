using System.ComponentModel.DataAnnotations;
using VSOP.Domain.DbModels.Worlds;
using VSOP.Domain.Primitives;

namespace VSOP.Domain.DbModels.Commodities;

public class Commodity : Entity, IEquatable<Commodity>
{
    private Commodity(Guid id, Guid worldId, string name) : base(id)
    {
        WorldId = worldId;
        Name = name;
    }

    public string Name { get; private set; }

    public Guid WorldId { get; private init; }
    public World World { get; private set; }

    public static Commodity Create(Guid worldId, string name)
    {
        if (worldId == Guid.Empty)
            throw new ValidationException("World Id can't be or empty");

        if (string.IsNullOrEmpty(name))
            throw new ValidationException("Name can't be null or empty");

        return new(Guid.NewGuid(), worldId, name);
    }

    public bool Equals(Commodity? other)
    {
        return Id == other?.Id;
    }
}