using VSOP.Application.Abstractions.Messaging;
using VSOP.Domain.DbModels.Regions;

namespace VSOP.Application.Requests.RegionStories.Commands.CreateRegionStoriesCommands
{
    public sealed record UpdateRegionCommand(Guid regionId) : ICommand<Region>
}
