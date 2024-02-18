using VSOP.Application.Abstractions.Messaging;
using VSOP.Domain.DbModels.Commodities;

namespace VSOP.Application.Requests.Commodities.Commands.UpdateCommodity;

public sealed record UpdateCommodityCommand(Guid Id, string name) : ICommand<Commodity>;
