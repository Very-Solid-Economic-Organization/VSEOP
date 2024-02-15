using VSOP.Application.Abstractions.Messaging;

namespace VSOP.Application.Requests.Commodities.Commands.RemoveCommodity;

public sealed record RemoveCommodityCommand(Guid Id) : ICommand;
