using System.ComponentModel.DataAnnotations;
using VSOP.Domain.Primitives;

namespace VSOP.Domain.DbModels.Regions;

/// <summary>Объект регионального склада в котором находятся все доступные предметы потребления данного региона</summary>
public class RegionStore : Entity, IEquatable<RegionStore>
{
    private RegionStore(Guid id, Guid regionId) : base(id)
    {
        RegionId = regionId;
    }

    /// <summary>Список всех доступных предметов потребления данного региона</summary>
    public HashSet<StoredCommodity> StoredCommodities = new();

    /// <summary>Id региона к которому пренадлежит склад</summary>
    public Guid RegionId { get; private init; }

    /// <summary>Метод создания регионального склада</summary>
    /// <param name="regionId">Id региона к которому пренадлежит склад</param>
    /// <returns>Новый объект регионального склада</returns>
    /// <exception cref="ValidationException">Ошибка валидации переданных параметров</exception>
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