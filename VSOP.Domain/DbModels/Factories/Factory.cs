using System.ComponentModel.DataAnnotations;
using VSOP.Models.DbModels.Countries;
using VSOP.Models.DbModels.Processes;
using VSOP.Models.Primitives;

namespace VSOP.Models.DbModels.Factories;

public abstract class Factory : Entity, IEquatable<Factory>
{
    public Factory(Guid id, Guid regionId) : base(id)
    {
        RegionId = regionId;
    }

    public Guid RegionId { get; private init; }

    public List<BaseProcess> Processes { get; private init; } = [];

    public bool Equals(Factory? other)
    {
        return Id == other?.Id;
    }
}