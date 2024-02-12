using VSOP.Application.Abstractions.Messaging;
using VSOP.Domain.DbModels.Countries;

namespace VSOP.Application.Requests.Countries.Queries.GetCountryById
{
    public sealed record GetCountryByIdQuery(Guid Id) : IQuery<Country>;

}
