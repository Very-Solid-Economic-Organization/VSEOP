using VSOP.Application.Abstractions.Messaging;
using VSOP.Domain.DbModels.Factories;

namespace VSOP.Application.Requests.Factories.Queries.GetFactoryById
{
    public sealed record GetFactoryByIdQuery(Guid Id) : IQuery<Factory>;

}
