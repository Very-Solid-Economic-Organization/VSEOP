using VSOP.Application.Abstractions.Messaging;
using VSOP.Domain.DbModels.Producers.ProducerProsesses;

namespace VSOP.Application.Requests.ProducerProcesses.Commands.CreateProducerProcess;

public sealed record CreateProducerProcessCommand(
    Guid producerId,
    Guid processId,
    uint ProcessesCount) : ICommand<ProducerProcess>;
