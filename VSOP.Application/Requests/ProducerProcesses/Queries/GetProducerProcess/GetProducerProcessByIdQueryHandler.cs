using System.Net;
using VSOP.Application.Abstractions.Messaging;
using VSOP.Domain.DbModels.Producers.ProducerProsesses;
using VSOP.Domain.Primitives.Results;

namespace VSOP.Application.Requests.ProducerProcesses.Queries.GetProducerProcess;


internal sealed class GetProducerProcessByIdQueryHandler : IQueryHandler<GetProducerProcessByIdQuery, ProducerProcess>
{
    private readonly IProducerProcessRepository _repository;

    public GetProducerProcessByIdQueryHandler(IProducerProcessRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ProducerProcess>> Handle(GetProducerProcessByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (result is null)
            return Result.Success(result, HttpStatusCode.NoContent);

        return Result.Success(result);
    }
}