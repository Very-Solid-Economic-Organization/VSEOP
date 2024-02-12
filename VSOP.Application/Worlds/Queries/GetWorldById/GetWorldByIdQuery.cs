using FluentValidation;
using System.Net;
using VSOP.Application.Abstractions.Messaging;
using VSOP.Domain.DbModels.Worlds;
using VSOP.Domain.Primitives;
using VSOP.Domain.Primitives.Results;
using VSOP.Persistence.Repositories;

namespace VSOP.Application.Worlds.Queries.GetWorldById;

internal class GetWorldByIdQueryValidator : AbstractValidator<GetWorldByIdQuery>
{
    public GetWorldByIdQueryValidator()
    {
        RuleFor(x => x.Id).NotNull();
    }
}

public sealed record GetWorldByIdQuery(Guid Id) : IQuery<World>;

internal sealed class GetWorldByIdQueryHandler : IQueryHandler<GetWorldByIdQuery, World>
{
    private readonly IWorldRepository _worldRepository;

    public GetWorldByIdQueryHandler(IWorldRepository worldRepository)
    {
        _worldRepository = worldRepository;
    }

    public async Task<Result<World>> Handle(GetWorldByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _worldRepository.GetByIdAsync(request.Id, cancellationToken);
        if (result is null)
            return Result.Failure<World>(new Error(
                HttpStatusCode.NoContent,
                $"No worlds were found by {request.Id}"));

        return Result.Success(result);
    }
}