using VSOP.Application.Abstractions.Messaging;
using VSOP.Domain.DbModels.Producers;

namespace VSOP.Application.Requests.Producers.Queries.GetProducerById
{
    public sealed record GetProducerByIdQuery(Guid Id, bool IncludeProcesses = false) : IQuery<Producer>;

}
