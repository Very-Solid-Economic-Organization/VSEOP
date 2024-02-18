using VSOP.Application.Abstractions.Messaging;
using VSOP.Domain.DbModels.Regions;

namespace VSOP.Application.Requests.StoredCommodities.Commands.CreateStoredCommodity;

public sealed record CreateStoredCommodityCommand(
    Guid commodityId,
    float quantity,
    ulong selfCost,
    ulong price,
    int currentDemand) : ICommand<StoredCommodity>;
