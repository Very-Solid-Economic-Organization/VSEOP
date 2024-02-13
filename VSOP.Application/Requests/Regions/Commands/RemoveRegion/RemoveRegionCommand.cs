using VSOP.Application.Abstractions.Messaging;

namespace VSOP.Application.Requests.Regions.Commands.RemoveRegionCommands
{
    public sealed record RemoveRegionCommand(Guid Id) : ICommand;
}
