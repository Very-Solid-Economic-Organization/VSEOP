namespace VSOP.Domain.Primitives;

/// <summary>Абстрактное представление данных в бд</summary>
public abstract class Entity
{
    /// <summary>
    /// Инициализирует новый экземпляр <see cref="Entity"/> класса
    /// </summary>
    /// <param name="id">Ид сущности</param>
    protected Entity(Guid id)
    {
        Id = id;
    }

    /// <summary>Ид сущности</summary>
    public Guid Id { get; protected init; }

    public override bool Equals(object? otherObj)
    {
        return otherObj is Entity other && Id == other.Id;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}