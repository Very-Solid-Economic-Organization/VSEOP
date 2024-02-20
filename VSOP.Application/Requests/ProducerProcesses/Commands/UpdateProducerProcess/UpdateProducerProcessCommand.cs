using VSOP.Application.Abstractions.Messaging;
using VSOP.Domain.DbModels.Producers.ProducerProsesses;

namespace VSOP.Application.Requests.ProducerProcesses.Commands.UpdateProducerProcess;

public sealed record UpdateProducerProcessCommand(
    Guid Id,
    uint ProcessesCount) : ICommand<ProducerProcess>;
