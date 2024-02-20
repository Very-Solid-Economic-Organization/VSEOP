using VSOP.Application.Abstractions.Messaging;
using VSOP.Domain.DbModels.Processes.ProcessedCommodities;

namespace VSOP.Application.Requests.ProcessedCommodities.Commands.UpdateProcessedCommodity;

public sealed record UpdateProcessedCommodityCommand(
    Guid Id,
    float quantity) : ICommand<ProcessedCommodity>; //TODO: сделать nullable чтобы можно было обновлять только not-null поля
