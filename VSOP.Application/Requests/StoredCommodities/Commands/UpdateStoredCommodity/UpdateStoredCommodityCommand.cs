using VSOP.Application.Abstractions.Messaging;
using VSOP.Domain.DbModels.Regions;

namespace VSOP.Application.Requests.StoredCommodities.Commands.UpdateStoredCommodity;

public sealed record UpdateStoredCommodityCommand(
    Guid Id,
    float? quantity,
    ulong? selfCost,
    ulong? price,
    int? currentDemand) : ICommand<StoredCommodity>; //TODO: сделать nullable чтобы можно было обновлять только not-null поля
