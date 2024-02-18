using System.ComponentModel.DataAnnotations;
using VSOP.Domain.DbModels.Commodities;
using VSOP.Domain.DbModels.Enums;
using VSOP.Domain.Primitives;

namespace VSOP.Domain.DbModels.Producers;

/// <summary>Объект обрабатываемого предмета потребления относящегося к производственному процессу</summary>
public class ProcessedCommodity : Entity
{
    private ProcessedCommodity(Guid id, Guid processId, Guid commodityId, ProcessedCommodityType type, float quantity) : base(id)
    {
        ProcessId = processId;
        CommodityId = commodityId;
        Type = type;
        Quantity = quantity;
    }

    /// <summary>Id процесса к которому относится обрабатываемый предмет потребления</summary>
    public Guid ProcessId { get; private init; }

    public Process Process { get; private set; }

    /// <summary>Id объекта потребления к которому относиться обрабатываемый предмет потребления</summary>
    public Guid CommodityId { get; private init; }

    public Commodity Commodity { get; private set; }

    /// <summary>Тип обрабатываемого предмета потребления</summary>
    public ProcessedCommodityType Type { get; private init; }

    /// <summary>Кол-во обрабатываемого предмета потребления участвующего в процессе производства</summary>
    public float Quantity { get; private set; } = 0;

    /// <summary>
    /// Метод создания нового обрабатываемого предмета потребления с типом "Потребляемый"
    /// </summary>
    /// <param name="processId">Id процесса к которому относится обрабатываемый предмет потребления</param>
    /// <param name="commodityId">Id объекта потребления к которому относиться обрабатываемый предмет потребления</param>
    /// <param name="quantity">Кол-во обрабатываемого предмета потребления участвующего в процессе производства</param>
    /// <returns>Новый объект обрабатываемого предмета потребления с типом "Потребляемый"</returns>
    public static ProcessedCommodity CreateConsumedCommodity(Guid processId, Guid commodityId, float quantity)
    {
        CreationValidation(processId, commodityId, quantity);

        return new ProcessedCommodity(Guid.NewGuid(), processId, commodityId, ProcessedCommodityType.Used, quantity);
    }

    /// <summary>
    /// Метод создания нового обрабатываемого предмета потребления с типом "Произведенный"
    /// </summary>
    /// <param name="processId">Id процесса к которому относится обрабатываемый предмет потребления</param>
    /// <param name="commodityId">Id объекта потребления к которому относиться обрабатываемый предмет потребления</param>
    /// <param name="quantity">Кол-во обрабатываемого предмета потребления участвующего в процессе производства</param>
    /// <returns>Новый объект обрабатываемого предмета потребления с типом "Произведенный"</returns>
    public static ProcessedCommodity CreateProducedCommodity(Guid processId, Guid commodityId, float quantity)
    {
        CreationValidation(processId, commodityId, quantity);

        return new ProcessedCommodity(Guid.NewGuid(), processId, commodityId, ProcessedCommodityType.Produced, quantity);
    }

    /// <summary>
    /// Метод валидации параметров для создания нового обрабатываемого предмета потребления
    /// </summary>
    /// <exception cref="ValidationException">Ошибка валидации переданных параметров</exception>
    static void CreationValidation(Guid processId, Guid commodityId, float quantity)
    {
        if (processId == Guid.Empty)
            throw new ValidationException("Process Id can't be empty");

        if (commodityId == Guid.Empty)
            throw new ValidationException("Commodity Id can't be empty");

        if (quantity < 1)
            throw new ValidationException("Quantity cant't be zero or negative");
    }

    /// <summary>
    /// Метод валидации параметров для создания нового обрабатываемого предмета потребления
    /// </summary>
    /// <exception cref="ValidationException">Ошибка валидации переданных параметров</exception>
    public void Update(float quantity)
    {
        if (quantity < 1)
            throw new ValidationException("Quantity cant't be zero or negative");
        Quantity = quantity;
    }
}