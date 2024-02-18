using VSOP.Application.Abstractions.Messaging;
using VSOP.Domain.DbModels.Regions;

namespace VSOP.Application.Requests.Regions.Commands.UpdateRegion
{
    public sealed record UpdateRegionCommand(Guid Id, string name) : ICommand<Region>;
}
