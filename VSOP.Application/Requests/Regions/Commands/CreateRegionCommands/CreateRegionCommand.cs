using VSOP.Application.Abstractions.Messaging;
using VSOP.Domain.DbModels.Regions;

namespace VSOP.Application.Requests.Regions.Commands.CreateRegionCommands;

public sealed record CreateRegionCommand(Guid countryId, string name) : ICommand<Region>;
