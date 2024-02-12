using System.Net;
using VSOP.Application.Abstractions.Messaging;
using VSOP.Domain.DbModels.Regions;
using VSOP.Domain.DbModels.Worlds;
using VSOP.Domain.Primitives;
using VSOP.Domain.Primitives.Results;

namespace VSOP.Application.Requests.RegionStores.Queries.GetRegionStoreById;


internal sealed class GetRegionStoreByIdQueryHandler : IQueryHandler<GetRegionStoreByIdQuery, RegionStore>
{
    private readonly IRegionStoreRepository _repository;

    public GetRegionStoreByIdQueryHandler(IRegionStoreRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<RegionStore>> Handle(GetRegionStoreByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (result is null)
            return Result.Failure<RegionStore>(new Error(
                HttpStatusCode.NoContent, //TODO: Подумать над HTMLStatusCode подходящим для ситуации
                $"No {nameof(RegionStore)} were found for Id {request.Id}"));

        return Result.Success<RegionStore>(result);
    }
}