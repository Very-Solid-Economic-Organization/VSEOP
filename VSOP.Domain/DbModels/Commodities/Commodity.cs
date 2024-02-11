using System.ComponentModel.DataAnnotations;
using VSOP.Domain.Primitives;

namespace VSOP.Domain.DbModels.Comodities;

public class Commodity : Entity, IEquatable<Commodity>
{
    public Commodity(Guid id, string name) : base(id)
    {
        Name = name;
    }

    public string Name { get; private init; }

    public static Commodity Create(string name)
    {
        if (string.IsNullOrEmpty(name))
            throw new ValidationException("Name can't be null or empty");

        return new(Guid.NewGuid(), name);
    }

    public bool Equals(Commodity? other)
    {
        return Id == other?.Id;
    }
}