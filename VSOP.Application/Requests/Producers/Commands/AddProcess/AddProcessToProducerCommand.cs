using VSOP.Application.Abstractions.Messaging;
using VSOP.Domain.DbModels.Producers;

namespace VSOP.Application.Requests.Producers.Commands.AddProcess;

public sealed record AddProcessToProducerCommand(Guid producerId, Guid processId) : ICommand<Producer>;
