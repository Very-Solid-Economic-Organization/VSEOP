using VSOP.Application.Abstractions.Messaging;
using VSOP.Domain.DbModels.Producers;

namespace VSOP.Application.Requests.ProcessedCommodities.Commands.CreateProcessedCommodity;

public sealed record CreateProcessedCommodityCommand(
    Guid processId,
    Guid commodityId,
    int processedCommodityType,
    float quantity) : ICommand<ProcessedCommodity>;
