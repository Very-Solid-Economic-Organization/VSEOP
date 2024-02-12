using System.ComponentModel.DataAnnotations;
using VSOP.Domain.Primitives;

namespace VSOP.Domain.DbModels.Producers;

public class Process : Entity, IEquatable<Process>
{
    private Process(Guid id, int processesCount) : base(id)
    {
        ProcessesCount = processesCount;
    }

    #region overthink-нуть
    /// <summary>Не говнокод, а филигранное решение проблемы</summary>
    public HashSet<ProcessedCommodity> CosumedCommdities => ProcessedCommodities.Where(x => x.Type == Enums.ProcessedComodityType.Used).ToHashSet();
    public HashSet<ProcessedCommodity> ProducedCommdities => ProcessedCommodities.Where(x => x.Type == Enums.ProcessedComodityType.Produced).ToHashSet();
    public HashSet<ProcessedCommodity> ProcessedCommodities { get; private set; } = new();
    #endregion

    public int ProcessesCount { get; set; } = 0;

    public HashSet<Producer> Factories { get; private set; }


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
