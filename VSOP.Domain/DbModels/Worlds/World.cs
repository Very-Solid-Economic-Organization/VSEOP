using System.ComponentModel.DataAnnotations;
using VSOP.Models.Primitives;

namespace VSOP.Models.DbModels.Worlds;

public class World : Entity
{
    private World(Guid id, string name, Guid masterId) : base(id)
    {
        Name = name;
        MasterId = masterId;
    }

    public string Name { get; private set; }

    public Guid MasterId { get; set; }

    public static World Create(string name, Guid guid)
    {
        if (string.IsNullOrEmpty(name))
            throw new ValidationException("Name property can't be null or empty");

        return new World(Guid.NewGuid(), name, guid);
    }
}