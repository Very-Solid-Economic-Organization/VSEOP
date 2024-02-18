using VSOP.Application.Abstractions.Messaging;
using VSOP.Domain.DbModels.Worlds;

namespace VSOP.Application.Requests.Worlds.Commads.CreateWorld;

public sealed record CreateWorldCommand(string name) : ICommand<World>;