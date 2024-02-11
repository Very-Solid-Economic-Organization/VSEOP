using VSOP.Models.DbModels.Countries;
using VSOP.Models.DbModels.StoredCommodities;
using VSOP.Models.Primitives;

namespace VSOP.Models.DbModels.Stories
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
