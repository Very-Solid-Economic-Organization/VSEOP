using VSOP.Application.Abstractions.Messaging;
using VSOP.Domain.DbModels.Commodities;
using VSOP.Domain.DbModels.Countries;

namespace VSOP.Application.Requests.Commodities.Commands.CreateCommodity;

public sealed record CreateCommodityCommand(Guid WorldId, string name) : ICommand<Commodity>;
