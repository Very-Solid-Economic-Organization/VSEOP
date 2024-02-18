using VSOP.Application.Abstractions.Messaging;

namespace VSOP.Application.Requests.ProcessedCommodities.Commands.RemoveProcessedCommodity;

public sealed record RemoveProcessedCommodityCommand(Guid Id) : ICommand;
