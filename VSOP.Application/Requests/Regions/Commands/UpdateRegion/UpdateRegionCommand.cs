using VSOP.Application.Abstractions.Messaging;
using VSOP.Domain.DbModels.Regions;

namespace VSOP.Application.Requests.Regions.Commands.UpdateRegionCommands
{
    public sealed record UpdateRegionCommand(Guid Id, string name) : ICommand<Region>;
}
