using VSOP.Models.Primitives;

namespace VSOP.Models.DbModels.Factories;

public abstract class Factory : Entity
{
    public Factory( Guid id , Guid regionId) : base(id)
    {
        RegionId = regionId;
    }

    public Guid RegionId { get; set; }


}