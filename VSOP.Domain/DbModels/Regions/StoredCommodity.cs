using System.ComponentModel.DataAnnotations;
using VSOP.Domain.DbModels.Commodities;
using VSOP.Domain.DbModels.Enums;
using VSOP.Domain.Primitives;

namespace VSOP.Domain.DbModels.Regions;

public class StoredCommodity : Entity, IEquatable<StoredCommodity>
{
    private StoredCommodity(Guid id, Guid commodityId, float quantity, ulong selfCost, ulong price, Demand currentDemand) : base(id)
    {
        CommodityId = commodityId;
        Quantity = quantity;
        SelfCost = selfCost;
        Price = price;
        CurrentDemand = currentDemand;
    }
   
    /// <summary>Для efcore</summary>
    private StoredCommodity(Guid id, Guid commodityId, float quantity, ulong selfCost, ulong price) : base(id)
    {
        CommodityId = commodityId;
        Quantity = quantity;
        SelfCost = selfCost;
        Price = price;   
    } //TODO: осознать как обойти проблему

    public Guid CommodityId { get; private init; }

    public Commodity Commodity { get; private set; }

    public float Quantity { get; private init; } = 0;

    public ulong SelfCost { get; private set; } = 0;

    public ulong Price { get; private set; } = 0;

    public Demand CurrentDemand { get; private set; } = Demand.Medium;

    public static StoredCommodity Create(Guid commodityId, float quantity, ulong selfCost, ulong price, Demand demand)
    {
        if (commodityId == Guid.Empty)
            throw new ValidationException("Commodity Id can't be empty");

        if (IsNegative(quantity))
            throw new ValidationException("Quantity value can't be negative");

        return new(Guid.NewGuid(), commodityId, quantity, selfCost, price, demand);
    }

    private static bool IsNegative(float value) =>
         value < 0;

    public bool Equals(StoredCommodity? other)
    {
        return Id == other?.Id;
    }
}
