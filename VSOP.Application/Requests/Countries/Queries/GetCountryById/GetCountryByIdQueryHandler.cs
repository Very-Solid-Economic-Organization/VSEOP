using System.Net;
using VSOP.Application.Abstractions.Messaging;
using VSOP.Domain.DbModels.Countries;
using VSOP.Domain.Primitives;
using VSOP.Domain.Primitives.Results;

namespace VSOP.Application.Requests.Countries.Queries.GetCountryById;

internal sealed class GetCountryByIdQueryHandler : IQueryHandler<GetCountryByIdQuery, Country>
{
    private readonly ICountryRepository _repository;

    public GetCountryByIdQueryHandler(ICountryRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<Country>> Handle(GetCountryByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (result is null)
            return Result.Success(result, HttpStatusCode.NoContent);

        return Result.Success(result);
    }
}
