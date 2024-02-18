using VSOP.Application.Abstractions.Messaging;
using VSOP.Domain.DbModels.Worlds;

namespace VSOP.Application.Requests.Worlds.Commads.UpdateWorld
{
    public sealed record UpdateWorldCommand(Guid Id, string Name) : ICommand<World>;
}
