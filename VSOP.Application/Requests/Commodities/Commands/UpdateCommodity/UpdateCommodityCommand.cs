using VSOP.Application.Abstractions.Messaging;
using VSOP.Domain.DbModels.Commodities;
using VSOP.Domain.DbModels.Countries;

namespace VSOP.Application.Requests.Commodities.Commands.UpdateCommodity;

public sealed record UpdateCommodityCommand(Guid Id, string name) : ICommand<Commodity>;
