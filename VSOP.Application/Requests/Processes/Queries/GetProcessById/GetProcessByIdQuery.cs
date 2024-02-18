using VSOP.Application.Abstractions.Messaging;
using VSOP.Domain.DbModels.Producers;

namespace VSOP.Application.Requests.Processes.Queries.GetProcessById
{
    public sealed record GetProcessByIdQuery(Guid Id, bool IncludeCommodities = true) : IQuery<Process>;

}
