using System.ComponentModel.DataAnnotations;
using VSOP.Domain.DbModels.Countries;
using VSOP.Domain.DbModels.Producers;
using VSOP.Domain.Primitives;

namespace VSOP.Domain.DbModels.Regions;

/// <summary>Объект региона страны</summary>
public class Region : Entity, IEquatable<Region>
{
    private Region(Guid id, string name, Guid countryId) : base(id)
    {
        Name = name;
        CountryId = countryId;
        RegionStore = RegionStore.Create(id);
        RegionStoreId = RegionStore.Id;
    }

    /// <summary>Наименование</summary>
    public string Name { get; private set; }

    /// <summary>Id страны к которой пренадлежит регион</summary>
    public Guid CountryId { get; private set; }
    public Country Country { get; private set; }

    /// <summary>Id регионального </summary>
    public Guid RegionStoreId { get; private init; }
    public RegionStore RegionStore { get; private set; }

    /// <summary>Список производящих объектов относящихся к данному региону</summary>
    public HashSet<Producer> Producers { get; private set; } = new();

    /// <summary>
    /// Метод создания нового региона
    /// </summary>
    /// <param name="name">Наименование региона</param>
    /// <param name="countryId">Id страны к которой относится данный регион</param>
    /// <returns>Новый объект региона</returns>
    /// <exception cref="ValidationException">Ошибка валидации переданных параметров</exception>
    public static Region Create(string name, Guid countryId)
    {
        if (string.IsNullOrEmpty(name))
            throw new ValidationException("Name can't be null or empty");

        if (countryId == Guid.Empty)
            throw new ValidationException("Empty countryId is not allowed");

        return new Region(Guid.NewGuid(), name, countryId);
    }

    /// <summary>
    /// Метод обновления объекта Региона
    /// </summary>
    /// <param name="name">Наименование региона</param>
    public void Update(string? name/*, Guid? countryId*/)
    {
        if (!string.IsNullOrEmpty(name))
            Name = name;

        //if (countryId != null && countryId != Guid.Empty)
        //    CountryId = countryId
    }

    public bool Equals(Region? other)
    {
        return Id == other?.Id;
    }
}