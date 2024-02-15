using VSOP.Application.Abstractions.Messaging;

namespace VSOP.Application.Requests.StoredCommodities.Commands.RemoveStoredCommodity;

public sealed record RemoveStoredCommodityCommand(Guid Id) : ICommand;
