using System.ComponentModel.DataAnnotations;
using VSOP.Domain.DbModels.Regions;
using VSOP.Domain.DbModels.Worlds;
using VSOP.Domain.Primitives;

namespace VSOP.Domain.DbModels.Countries;

/// <summary>Базовое представление страны</summary>
public class Country : Entity, IEquatable<Country>
{
    private Country(Guid id, string name, Guid worldId) : base(id)
    {
        Name = name;
        WorldId = worldId;
    }

    /// <summary>Наименование</summary>
    public string Name { get; set; }

    /// <summary>Id мира в котором существует страна</summary>
    public Guid WorldId { get; private init; }

    public World World { get; private set; }

    /// <summary>Список регионов принадлежащих данной стране</summary>
    public HashSet<Region> Regions { get; private set; } = [];

    /// <summary>
    /// Метод создания новой страны
    /// </summary>
    /// <param name="name">Наименование страны</param>
    /// <param name="worldId">Id мира в котором существует страна</param>
    /// <returns>Созданный объект страны</returns>
    /// <exception cref="ValidationException">Ошибка валедации переданных параметров</exception>
    public static Country Create(string name, Guid worldId)
    {
        if (string.IsNullOrEmpty(name))
            throw new ValidationException("Name can't be null or empty");

        if (worldId == Guid.Empty)
            throw new ValidationException("World Id can't be empty");

        return new(Guid.NewGuid(), name, worldId);
    }

    /// <summary>
    /// Метод обновления сущности страны
    /// </summary>
    /// <param name="name">Наименование страны</param>
    public void Update(string? name/*, Guid? worldId*/)
    {
        if (!string.IsNullOrEmpty(name))
            Name = name;

        //if (worldId != null && worldId != Guid.Empty)
        //    WorldId = worldId
    }

    public bool Equals(Country? other)
    {
        return Id == other?.Id;
    }
}