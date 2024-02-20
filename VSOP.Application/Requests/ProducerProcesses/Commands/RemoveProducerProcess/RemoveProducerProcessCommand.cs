using VSOP.Application.Abstractions.Messaging;

namespace VSOP.Application.Requests.ProducerProcesses.Commands.RemoveProducerProcess;

public sealed record RemoveProducerProcessCommand(Guid Id) : ICommand;
