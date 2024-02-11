using VSOP.Domain.DbModels.Countries;
using VSOP.Domain.DbModels.StoredCommodities;
using VSOP.Domain.Primitives;

namespace VSOP.Domain.DbModels.Stories
{
    internal class RegionStore : Entity, IEquatable<RegionStore>
    {
        public RegionStore(Guid id) : base(id)
        {
        }

        public List<BaseStoredCommodity> StoredCommodities = [];

        public static RegionStore Create()
        {
            return new(Guid.NewGuid());
        }

        public bool Equals(RegionStore? other)
        {
            return Id == other?.Id;
        }
    }
}
