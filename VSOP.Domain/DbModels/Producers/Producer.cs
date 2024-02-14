using VSOP.Domain.DbModels.Regions;
using VSOP.Domain.Primitives;

namespace VSOP.Domain.DbModels.Producers;

/// <summary>Базовое представление производящего объекта. (Например: фабрика, шахта, мануфактура и т.д)</summary>
public abstract class Producer : Entity, IEquatable<Producer>
{
    protected Producer(Guid id, Guid regionId, string name) : base(id)
    {
        RegionId = regionId;
        Name = name;
    }

    /// <summary>Наименование</summary>
    public string Name { get; private set; }

    /// <summary>Id региона к которому принадлежит производящий объект</summary>
    public Guid RegionId { get; private init; }
    public Region Region { get; private set; }

    /// <summary>Список процессов принадлежащих к производящему объект</summary>
    public HashSet<Process> Processes { get; private set; } = new();

    public bool Equals(Producer? other)
    {
        return Id == other?.Id;
    }
}