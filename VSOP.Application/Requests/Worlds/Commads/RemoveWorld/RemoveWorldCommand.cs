using VSOP.Application.Abstractions.Messaging;

namespace VSOP.Application.Requests.Worlds.Commads.RemoveWorld;

public sealed record RemoveWorldCommand(Guid worldGuid) : ICommand;
