using System.Net;
using VSOP.Application.Abstractions.Messaging;
using VSOP.Domain.DbModels.Producers;
using VSOP.Domain.Primitives.Results;

namespace VSOP.Application.Requests.Producers.Queries.GetProducersList;

internal sealed class GetProducersListQueryHandler : IQueryHandler<GetProducersListQuery, List<Producer>>
{
    private readonly IProducerRepository _repository;

    public GetProducersListQueryHandler(IProducerRepository Repository)
    {
        _repository = Repository;
    }

    public async Task<Result<List<Producer>>> Handle(GetProducersListQuery request, CancellationToken cancellationToken)
    {
        List<Producer> result;
        if (request.IncludeProcesses)
            result = await _repository.GetAllAsync(cancellationToken);
        else
            result = await _repository.GetAllAsync(cancellationToken);

        if (result is null || result.Count() == 0)
            return Result.Success(result, HttpStatusCode.NoContent);

        return Result.Success(result);
    }
}
