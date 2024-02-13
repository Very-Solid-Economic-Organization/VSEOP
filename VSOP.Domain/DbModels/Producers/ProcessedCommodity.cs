using System.ComponentModel.DataAnnotations;
using VSOP.Domain.DbModels.Commodities;
using VSOP.Domain.DbModels.Enums;
using VSOP.Domain.Primitives;

namespace VSOP.Domain.DbModels.Producers;
public class ProcessedCommodity : Entity
{
    private ProcessedCommodity(Guid id, Guid processId, Guid commodityId, ProcessedComodityType type, float quantity) : base(id)
    {
        ProcessId = processId;
        CommodityId = commodityId;
        Type = type;
        Quantity = quantity;
    }

    public Guid ProcessId { get; private init; }

    public Process Process { get; private set; }

    public Guid CommodityId { get; private init; }

    public Commodity Commodity { get; private set; }

    public ProcessedComodityType Type { get; private init; }

    public float Quantity { get; private set; } = 0;

    public static ProcessedCommodity CreateConsumingCommodity(Guid processId, Guid commodityId, float quantity)
    {
        CreationValidation(processId, commodityId, quantity);

        return new ProcessedCommodity(Guid.NewGuid(), processId, commodityId, ProcessedComodityType.Used, quantity);
    }

    public static ProcessedCommodity CreateProducingCommodity(Guid processId, Guid commodityId, float quantity)
    {
        CreationValidation(processId, commodityId, quantity);

        return new ProcessedCommodity(Guid.NewGuid(), processId, commodityId, ProcessedComodityType.Produced, quantity);
    }

    static void CreationValidation(Guid processId, Guid commodityId, float quantity)
    {
        if (processId == Guid.Empty)
            throw new ValidationException("Process Id can't be empty");

        if (commodityId == Guid.Empty)
            throw new ValidationException("Commodity Id can't be empty");

        if (quantity < 1)
            throw new ValidationException("Quantity cant't be zero or negative");
    }
}
