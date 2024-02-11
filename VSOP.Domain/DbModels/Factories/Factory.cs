using System.ComponentModel.DataAnnotations;
using VSOP.Domain.DbModels.Countries;
using VSOP.Domain.DbModels.Processes;
using VSOP.Domain.Primitives;

namespace VSOP.Domain.DbModels.Factories;

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