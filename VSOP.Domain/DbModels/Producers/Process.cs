using System.ComponentModel.DataAnnotations;
using VSOP.Domain.DbModels.Enums;
using VSOP.Domain.Primitives;

namespace VSOP.Domain.DbModels.Producers;

/// <summary>Базовое представление процесса производства</summary>
public class Process : Entity, IEquatable<Process>
{
    private Process(Guid id, string name) : base(id)
    {
        Name = name;
    }

    /// <summary>Наименование</summary>
    public string Name { get; private set; }

    #region overthink-нуть
    //Не говнокод, а филигранное решение проблемы

    /// <summary>Список потребляемых предметов потребления для производственного процесса</summary>
    public HashSet<ProcessedCommodity> CosumedCommdities => ProcessedCommodities.Where(x => x.Type == ProcessedCommodityType.Used).ToHashSet();

    /// <summary>Список производимых предметов потребления в ходе производственного процесса</summary>
    public HashSet<ProcessedCommodity> ProducedCommdities => ProcessedCommodities.Where(x => x.Type == ProcessedCommodityType.Produced).ToHashSet();

    /// <summary>Список всех предметов потребления относящихся к производственному процессу</summary>
    public HashSet<ProcessedCommodity> ProcessedCommodities { get; private set; } = new();
    #endregion

    /// <summary>Время затрачиваемое на производственный процесс в секундах</summary>
    public ulong ProcessTickrate { get; private set; }

    /// <summary>
    /// Метод создания нового процесса производства
    /// </summary>
    /// <param name="name">Наименование процесса производства</param>
    /// <returns>Нового объект процесса производства</returns>
    /// <exception cref="ValidationException">Ошибка валидации переданных параметров</exception>
    public static Process Create(string name)
    {
        if (string.IsNullOrEmpty(name))
            throw new ValidationException("Name property can't be null or empty");

        return new(Guid.NewGuid(), name);
    }

    /// <summary>
    /// Метод изменения процесса производства
    /// </summary>
    /// <param name="name">Наименование процесса производства</param>
    /// <returns>Нового объект процесса производства</returns>
    /// <exception cref="ValidationException">Ошибка валидации переданных параметров</exception>
    public void Update(string name)
    {
        if (string.IsNullOrEmpty(name))
            throw new ValidationException("Name property can't be null or empty");

        Name = name;
    }

    public bool Equals(Process? other)
    {
        return Id == other?.Id;
    }
}