using System.ComponentModel.DataAnnotations;
using VSOP.Domain.DbModels.Commodities;
using VSOP.Domain.DbModels.Enums;
using VSOP.Domain.Primitives;

namespace VSOP.Domain.DbModels.Regions;

/// <summary>Объект хранимого предмета потребления</summary>
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

    /// <summary>Id предмета потребления к которому относится данных хранимый предмет потребления</summary>
    public Guid CommodityId { get; private init; }
    public Commodity Commodity { get; private set; }

    /// <summary>Кол-во предметов потребления данного типа хранящихся на складе</summary>
    public float Quantity { get; private init; } = 0;

    /// <summary>Себестоимость данного хранимого предмета потребления</summary>
    public ulong SelfCost { get; private set; } = 0;

    /// <summary>Базовая цена продажи данного хранимого предмета потребления</summary>
    public ulong Price { get; private set; } = 0;

    /// <summary>Тип спроса для данного хранимого предмета потребления (По умолчанию - нормальный)</summary>
    public Demand CurrentDemand { get; private set; }

    /// <summary>Метод создания хранимого предмета потребления</summary>
    /// <param name="commodityId">Id предмета потребления к которому относится данных хранимый предмет потребления</param>
    /// <param name="quantity">Кол-во предметов потребления данного типа хранящихся на складе</param>
    /// <param name="selfCost">Себестоимость данного хранимого предмета потребления</param>
    /// <param name="price">Базовая цена продажи данного хранимого предмета потребления</param>
    /// <param name="demand">Тип спроса для данного хранимого предмета потребления (По умолчанию - нормальный)</param>
    /// <returns>Новый объект хранимого предмета потребления</returns>
    /// <exception cref="ValidationException">Ошибка валидации переданных параметров</exception>
    public static StoredCommodity Create(Guid commodityId, float quantity, ulong selfCost, ulong price, Demand demand = Demand.Medium)
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
