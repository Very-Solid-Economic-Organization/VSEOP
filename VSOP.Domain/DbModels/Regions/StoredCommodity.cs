using System.ComponentModel.DataAnnotations;
using VSOP.Domain.DbModels.Enums;
using VSOP.Domain.Primitives;

namespace VSOP.Domain.DbModels.Regions;

public class StoredCommodity : Entity, IEquatable<StoredCommodity>
{
    public StoredCommodity(Guid id, Guid commodityId, float quantity, ulong selfCost, ulong price, Demand demand = Demand.Medium) : base(id)
    {
        CommodityId = commodityId;
        Quantity = quantity;
        SelfCost = selfCost;
        Price = price;
        CurrentDemand = demand;
    }

    public Guid CommodityId { get; private init; }

    public float Quantity { get; private init; } = 0;

    public ulong SelfCost { get; set; } = 0;

    public ulong Price { get; set; } = 0;

    public Demand CurrentDemand { get; set; } = Demand.Medium;

    public static StoredCommodity Create(Guid commodityId, float quantity, ulong selfCost, ulong price)
    {
        if (commodityId == Guid.Empty)
            throw new ValidationException("Commodity Id can't be empty");

        if (IsNegative(quantity))
            throw new ValidationException("Quantity value can't be negative");

        return new(Guid.NewGuid(), commodityId, quantity, selfCost, price);
    }

    private static bool IsNegative(float value) =>
         value < 0;

    public bool Equals(StoredCommodity? other)
    {
        return Id == other?.Id;
    }
}
