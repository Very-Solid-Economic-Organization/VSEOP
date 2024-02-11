using System.ComponentModel.DataAnnotations;
using VSOP.Domain.DbModels.Countries;
using VSOP.Domain.DbModels.Enums;
using VSOP.Domain.DbModels.Processes;
using VSOP.Domain.Primitives;

namespace VSOP.Domain.DbModels.StoredCommodities
{
    internal class BaseStoredCommodity : Entity, IEquatable<BaseStoredCommodity>
    {
        public BaseStoredCommodity(Guid id, Guid commdodityId) : base(id)
        {
            CommdodityId = commdodityId;
        }

        public Guid CommdodityId { get; private init; }

        public int Quantity { get; private init; } = 0;

        public decimal SelfCost { get; set; } = decimal.Zero;

        public decimal Price { get; set; } = decimal.Zero;

        public Demand CurrentDemand { get; set; }

        public static BaseStoredCommodity Create(Guid commdodityId)
        {
            if (commdodityId == Guid.Empty)
                throw new ValidationException("Commdodity Id can't be empty");

            return new(Guid.NewGuid(), commdodityId);
        }

        public bool Equals(BaseStoredCommodity? other)
        {
            return Id == other?.Id;
        }
    }
}
