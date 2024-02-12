using VSOP.Application.Abstractions.Messaging;
using VSOP.Domain.DbModels.Worlds;

namespace VSOP.Application.Requests.Worlds.Commads.RemoveWorld;

public sealed record RemoveWorldCommand(Guid worldGuid) : ICommand;
