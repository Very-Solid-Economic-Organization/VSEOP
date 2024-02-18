using VSOP.Application.Abstractions.Messaging;
using VSOP.Domain.DbModels.Producers;

namespace VSOP.Application.Requests.Processes.Commands.UpdateProcess;

public sealed record UpdateProcessCommand(Guid Id, uint processesCount, string name) : ICommand<Process>;
