using VSOP.Application.Abstractions.Messaging;

namespace VSOP.Application.Requests.Regions.Commands.RemoveRegion
{
    public sealed record RemoveRegionCommand(Guid Id) : ICommand;
}
