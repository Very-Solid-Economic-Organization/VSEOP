using System.ComponentModel.DataAnnotations;
using VSOP.Domain.DbModels.Enums;
using VSOP.Domain.Primitives;

namespace VSOP.Domain.DbModels.Producers;

/// <summary>Базовое представление процесса производства</summary>
public class Process : Entity, IEquatable<Process>
{
    private Process(Guid id, int processesCount) : base(id)
    {
        ProcessesCount = processesCount;
    }

    #region overthink-нуть
    //Не говнокод, а филигранное решение проблемы

    /// <summary>Список потребляемых предметов потребления для производственного процесса</summary>
    public HashSet<ProcessedCommodity> CosumedCommdities => ProcessedCommodities.Where(x => x.Type == ProcessedCommodityType.Used).ToHashSet();

    /// <summary>Список производимых предметов потребления в ходе производственного процесса</summary>
    public HashSet<ProcessedCommodity> ProducedCommdities => ProcessedCommodities.Where(x => x.Type == ProcessedCommodityType.Produced).ToHashSet();

    /// <summary>Список всех предметов потребления относящихся к производственному процессу</summary>
    public HashSet<ProcessedCommodity> ProcessedCommodities { get; private set; } = new();
    #endregion

    /// <summary>Кол-во одновременно запущенных процессов данного типа</summary>
    public int ProcessesCount { get; private set; } = 0;

    /// <summary>Список производств в которых используется данных тип производства</summary>
    public HashSet<Producer> Producers { get; private set; }

    /// <summary>
    /// Метод создания нового процесса производства
    /// </summary>
    /// <param name="processesCount">Кол-во одновременно запущенных процессов данного типа</param>
    /// <returns>Нового объект процесса производства</returns>
    /// <exception cref="ValidationException">Ошибка валидации переданных параметров</exception>
    public static Process Create(int processesCount)
    {
        if (processesCount < 0)
            throw new ValidationException("ProcessesCount can't be negative");

        return new(Guid.NewGuid(), processesCount);
    }

    public bool Equals(Process? other)
    {
        return Id == other?.Id;
    }
}