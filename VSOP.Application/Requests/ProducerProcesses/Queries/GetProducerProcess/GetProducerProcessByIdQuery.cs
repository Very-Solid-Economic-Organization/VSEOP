using VSOP.Application.Abstractions.Messaging;
using VSOP.Domain.DbModels.Producers.ProducerProsesses;

namespace VSOP.Application.Requests.ProducerProcesses.Queries.GetProducerProcess
{
    public sealed record GetProducerProcessByIdQuery(Guid Id) : IQuery<ProducerProcess>;
}
