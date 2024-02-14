using System.ComponentModel.DataAnnotations;
using VSOP.Domain.DbModels.Commodities;
using VSOP.Domain.DbModels.Countries;
using VSOP.Domain.Primitives;

namespace VSOP.Domain.DbModels.Worlds;

/// <summary>Объект мира</summary>
public class World : Entity
{
    private World(Guid id, string name/*, Guid masterId*/) : base(id)
    {
        Name = name;
        //MasterId = masterId;
    }

    /// <summary>Наименование</summary>
    public string Name { get; private set; }

    //public Guid MasterId { get; private init; } //TODO: implement

    /// <summary>Список стран относящихся к данному миру</summary>
    public HashSet<Country> Countries { get; private set; } = new();

    /// <summary>Список предметов потребления относящихся к данному миру</summary>
    public HashSet<Commodity> Commodities { get; private set; } = new();

    /// <summary>
    /// Метод создания мира
    /// </summary>
    /// <param name="name">Наименование мира</param>
    /// <returns>Новый объект мира</returns>
    /// <exception cref="ValidationException">Ошибка валидации переданных параметров</exception>
    public static World Create(string name/*, Guid masterId*/)
    {
        if (string.IsNullOrEmpty(name))
            throw new ValidationException("Name property can't be null or empty");

        //if (masterId == Guid.Empty)
        //    throw new ValidationException("Game master Id can't be empty");

        return new World(Guid.NewGuid(), name/*, masterId*/);
    }

    public void Update(string? name/*, Guid? masterId*/)
    {
        if (!string.IsNullOrEmpty(name))
            Name = name;

        //if (masterId != null && masterId != Guid.Empty)
        //    MasterId = masterId
    }

    public bool Equals(Country? other)
    {
        return Id == other?.Id;
    }
}