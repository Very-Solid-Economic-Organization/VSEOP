using VSOP.Domain.DbModels.Countries;
using VSOP.Domain.Primitives;

namespace VSOP.Domain.DbModels.Stores
{
    internal class RegionStore : Entity, IEquatable<RegionStore>
    {
        public RegionStore(Guid id) : base(id)
        {
        }

        public HashSet<StoredCommodity> StoredCommodities = new();

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
