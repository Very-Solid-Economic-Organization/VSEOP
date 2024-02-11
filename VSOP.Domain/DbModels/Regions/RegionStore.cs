using System.ComponentModel.DataAnnotations;
using VSOP.Domain.Primitives;

namespace VSOP.Domain.DbModels.Regions;

public class RegionStore : Entity, IEquatable<RegionStore>
{
    private RegionStore(Guid id, Guid regionId) : base(id)
    {
        RegionId = regionId;
    }

    public HashSet<StoredCommodity> StoredCommodities = new();

    public Guid RegionId { get; private init; }

    public Region Region { get; private set; }

    public static RegionStore Create(Guid regionId)
    {
        if (regionId == Guid.Empty)
            throw new ValidationException("RegionId can't be default");

        return new(Guid.NewGuid(), regionId);
    }

    public bool Equals(RegionStore? other)
    {
        return Id == other?.Id;
    }
}
