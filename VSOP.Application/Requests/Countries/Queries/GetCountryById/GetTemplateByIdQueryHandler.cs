﻿using System.Net;
using VSOP.Application.Abstractions.Messaging;
using VSOP.Domain.DbModels.Countries;
using VSOP.Domain.Primitives;
using VSOP.Domain.Primitives.Results;

namespace VSOP.Application.Requests.Countries.Queries.GetCountryById;

internal sealed class GetCountryByIdQueryHandler : IQueryHandler<GetCountryByIdQuery, Country>
{
    private readonly ICountryRepository _Repository;

    public GetCountryByIdQueryHandler(ICountryRepository Repository)
    {
        _Repository = Repository;
    }

    public async Task<Result<Country>> Handle(GetCountryByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _Repository.GetByIdAsync(request.Id, cancellationToken);
        if (result is null)
            return Result.Failure<Country>(new Error(
                HttpStatusCode.NoContent,
                $"No countries were found for id {request.Id}"));

        return Result.Success(result);
    }
}