using VSOP.Application.Abstractions.Messaging;

namespace VSOP.Application.Requests.Processes.Commands.RemoveProcess;

public sealed record RemoveProcessCommand(Guid Id) : ICommand;
