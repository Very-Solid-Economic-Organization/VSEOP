using VSOP.Application.Abstractions.Messaging;
using VSOP.Domain.DbModels.Regions;

namespace VSOP.Application.Requests.RegionStories.Commands.CreateRegionStoriesCommands
{
    internal class UpdateRegionStoriesCommand(Guid regionId) : ICommand<RegionStore>
    {
    }
}
