using VSOP.Application.Abstractions.Messaging;

namespace VSOP.Application.Requests.RegionStories.Commands.CreateRegionStoriesCommands
{
    public sealed record RemoveRegionStoriesCommand(Guid toRemove) : ICommand;
}
