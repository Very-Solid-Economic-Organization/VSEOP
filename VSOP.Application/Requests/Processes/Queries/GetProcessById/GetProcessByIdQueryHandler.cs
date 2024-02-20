using System.Net;
using VSOP.Application.Abstractions.Messaging;
using VSOP.Domain.DbModels.Processes;
using VSOP.Domain.Primitives.Results;

namespace VSOP.Application.Requests.Processes.Queries.GetProcessById;

internal sealed class GetProcessByIdQueryHandler : IQueryHandler<GetProcessByIdQuery, Process>
{
    private readonly IProcessRepository _repository;

    public GetProcessByIdQueryHandler(IProcessRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<Process>> Handle(GetProcessByIdQuery request, CancellationToken cancellationToken)
    {
        Process? result;
        if (request.IncludeCommodities)
            result = await _repository.GetWithCommoditiesByIdAsync(request.Id, cancellationToken);
        else
            result = await _repository.GetByIdAsync(request.Id, cancellationToken);

        if (result is null)
            return Result.Success(result, HttpStatusCode.NoContent);

        return Result.Success(result);
    }
}
