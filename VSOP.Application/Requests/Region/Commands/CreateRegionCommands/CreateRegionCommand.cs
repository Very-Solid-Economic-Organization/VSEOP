using VSOP.Application.Abstractions.Messaging;
using VSOP.Domain.DbModels.Regions;

namespace VSOP.Application.Requests.RegionStories.Commands.CreateRegionStoriesCommands
{
    public sealed record CreateRegionCommand(string name, Guid countryId, Guid regionStoreId) : ICommand<Region>;
}
