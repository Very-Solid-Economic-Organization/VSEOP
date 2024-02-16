using System.ComponentModel.DataAnnotations;
using VSOP.Domain.DbModels.Producers;

namespace VSOP.Domain.DbModels.Factories;

/// <summary>Объект производственного здания (Фабрика)</summary>
public class Factory : Producer
{
    private Factory(Guid id, Guid regionId, string name) : base(id, regionId, name)
    {
    }

    /// <summary>
    /// Объект производственного здания (Фабрика)
    /// </summary>
    /// <param name="regionId">Id региона к которому принадлежит фабрика</param>
    /// <param name="name">Наименование фабрики</param>
    /// <returns>Новый объект фабрики</returns>
    /// <exception cref="ValidationException">Ошибка валидации переданных параметров</exception>
    public static Factory Create(Guid regionId, string name)
    {
        if (regionId == Guid.Empty)
            throw new ValidationException("Region Id can't be empty");

        if (string.IsNullOrEmpty(name))
            throw new ValidationException("Name can't be null or empty");

        return new Factory(Guid.NewGuid(), regionId, name);
    }
    public void Update(string? name/*, Guid? regionId*/)
    {
        if (!string.IsNullOrEmpty(name))
            Name = name;

        //if (regionId != null && regionId != Guid.Empty)
        //    RegionId = regionId
    }
}