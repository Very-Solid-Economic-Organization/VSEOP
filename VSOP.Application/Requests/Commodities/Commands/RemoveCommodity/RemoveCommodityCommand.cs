using VSOP.Application.Abstractions.Messaging;
using VSOP.Domain.DbModels.Countries;

namespace VSOP.Application.Requests.Commodities.Commands.RemoveCommodity;

public sealed record RemoveCommodityCommand(Guid Id) : ICommand;
