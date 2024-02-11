using VSOP.Application.Abstractions.Messaging;
using VSOP.Domain.DbModels.Worlds;

namespace VSOP.Application.Worlds.Commads.CreateWorld;

public sealed record GetWorldCommand(Guid Id) : ICommand<World>;
