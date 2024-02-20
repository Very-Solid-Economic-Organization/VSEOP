using VSOP.Application.Abstractions.Messaging;
using VSOP.Domain.DbModels.Processes;

namespace VSOP.Application.Requests.Processes.Commands.CreateProcess;

public sealed record CreateProcessCommand(string name, ulong processTickrate) : ICommand<Process>;
