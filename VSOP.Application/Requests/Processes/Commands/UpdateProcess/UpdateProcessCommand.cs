using VSOP.Application.Abstractions.Messaging;
using VSOP.Domain.DbModels.Processes;

namespace VSOP.Application.Requests.Processes.Commands.UpdateProcess;

public sealed record UpdateProcessCommand(
    Guid Id,
    string name,
    ulong processTickrate) : ICommand<Process>;
//TODO: Переделать в Nullable
