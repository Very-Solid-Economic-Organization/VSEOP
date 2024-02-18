using System.Net;
using VSOP.Application.Abstractions.Messaging;
using VSOP.Domain.DbModels.Factories;
using VSOP.Domain.Primitives.Results;

namespace VSOP.Application.Requests.Factories.Queries.GetFactoryById;

internal sealed class GetFactoryByIdQueryHandler : IQueryHandler<GetFactoryByIdQuery, Factory>
{
    private readonly IFactoryRepository _repository;

    public GetFactoryByIdQueryHandler(IFactoryRepository Repository)
    {
        _repository = Repository;
    }

    public async Task<Result<Factory>> Handle(GetFactoryByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (result is null)
            return Result.Success(result, HttpStatusCode.NoContent);

        return Result.Success(result);
    }
}
