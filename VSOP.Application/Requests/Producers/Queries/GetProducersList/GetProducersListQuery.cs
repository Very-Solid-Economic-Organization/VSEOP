using VSOP.Application.Abstractions.Messaging;
using VSOP.Domain.DbModels.Producers;

namespace VSOP.Application.Requests.Producers.Queries.GetProducersList
{
    public sealed record GetProducersListQuery(Guid Id, bool IncludeProcesses = false) : IQuery<List<Producer>>;

}
