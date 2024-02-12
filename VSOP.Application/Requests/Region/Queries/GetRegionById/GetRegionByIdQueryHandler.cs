﻿using System.Net;
using VSOP.Application.Abstractions.Messaging;
using VSOP.Domain.DbModels.Regions;
using VSOP.Domain.DbModels.Worlds;
using VSOP.Domain.Primitives;
using VSOP.Domain.Primitives.Results;

namespace VSOP.Application.Requests.RegionStories.Queries.GetRegionStoreById;


internal sealed class GetRegionByIdQueryHandler : IQueryHandler<GetRegionByIdQuery, Region>
{
    private readonly IRegionRepository _repository;

    public GetRegionByIdQueryHandler(IRegionRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<Region>> Handle(GetRegionByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (result is null)
            return Result.Failure<Region>(new Error(
                HttpStatusCode.NoContent, //TODO: Подумать над HTMLStatusCode подходящим для ситуации
                $"No {nameof(Region)} were found for Id {request.Id}"));

        return Result.Success(result);
    }
}