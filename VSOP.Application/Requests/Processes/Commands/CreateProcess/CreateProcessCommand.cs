using VSOP.Application.Abstractions.Messaging;
using VSOP.Domain.DbModels.Producers;

namespace VSOP.Application.Requests.Processes.Commands.CreateProcess;

public sealed record CreateProcessCommand(uint processesCount, string name) : ICommand<Process>;
