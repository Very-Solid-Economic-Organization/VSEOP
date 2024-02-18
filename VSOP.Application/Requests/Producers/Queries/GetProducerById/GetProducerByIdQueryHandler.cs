using System.Net;
using VSOP.Application.Abstractions.Messaging;
using VSOP.Domain.DbModels.Producers;
using VSOP.Domain.Primitives.Results;

namespace VSOP.Application.Requests.Producers.Queries.GetProducerById;

internal sealed class GetProducerByIdQueryHandler : IQueryHandler<GetProducerByIdQuery, Producer>
{
    private readonly IProducerRepository _repository;

    public GetProducerByIdQueryHandler(IProducerRepository Repository)
    {
        _repository = Repository;
    }

    public async Task<Result<Producer>> Handle(GetProducerByIdQuery request, CancellationToken cancellationToken)
    {
        Producer? result;
        if (request.IncludeProcesses)
            result = await _repository.GetWithProcessesByIdAsync(request.Id, cancellationToken);
        else
            result = await _repository.GetByIdAsync(request.Id, cancellationToken);

        if (result is null)
            return Result.Success(result, HttpStatusCode.NoContent);

        return Result.Success(result);
    }
}
