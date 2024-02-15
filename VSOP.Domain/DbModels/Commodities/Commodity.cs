using System.ComponentModel.DataAnnotations;
using VSOP.Domain.DbModels.Producers;
using VSOP.Domain.DbModels.Regions;
using VSOP.Domain.DbModels.Worlds;
using VSOP.Domain.Primitives;

namespace VSOP.Domain.DbModels.Commodities;

/// <summary>Базовый представление объект предмета потребления. Например: доска, слиток железа и т.д</summary>
public class Commodity : Entity, IEquatable<Commodity>
{
    private Commodity(Guid id, Guid worldId, string name) : base(id)
    {
        WorldId = worldId;
        Name = name;
    }

    /// <summary>Наименование</summary>
    public string Name { get; private set; }

    /// <summary>Id мира к которому принадлежит предмет потребления</summary>
    public Guid WorldId { get; private init; }
    public World World { get; private set; }

    /// <summary>
    /// Метод создания новой объекта потребления 
    /// </summary>
    /// <param name="worldId">Id мира к которому принадлежит предмет потребления</param>
    /// <param name="name">Наименование объекта потребления</param>
    /// <returns>Новый объект потребления</returns>
    /// <exception cref="ValidationException">Ошибка валидации переданных параметров</exception>
    public static Commodity Create(Guid worldId, string name)
    {
        if (worldId == Guid.Empty)
            throw new ValidationException("World Id can't be or empty");

        if (string.IsNullOrEmpty(name))
            throw new ValidationException("Name can't be null or empty");

        return new(Guid.NewGuid(), worldId, name);
    }

    public void Update(string? name/*, Guid? worldId*/)
    {
        if (!string.IsNullOrEmpty(name))
            Name = name;

        //if (worldId != null && worldId != Guid.Empty)
        //    WorldId = worldId
    }

    public bool Equals(Commodity? other)
    {
        return Id == other?.Id;
    }
}