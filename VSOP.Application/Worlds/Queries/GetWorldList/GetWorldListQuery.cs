using FluentValidation;
using System.Net;
using VSOP.Application.Abstractions.Messaging;
using VSOP.Domain.DbModels.Worlds;
using VSOP.Domain.Primitives;
using VSOP.Domain.Primitives.Results;
using VSOP.Persistence.Repositories;

namespace VSOP.Application.Worlds.Queries.GetWorldList;

public sealed record GetAllWorldCommand() : ICommand<List<World>>;

internal class GetAllWorldCommandValidator : AbstractValidator<GetAllWorldCommand>
{
    public GetAllWorldCommandValidator()
    {
        // RuleFor(x => x).NotNull();
    }
}

internal sealed class GetAllWorldCommandHandler : ICommandHandler<GetAllWorldCommand, List<World>>
{
    private readonly IWorldRepository _worldRepository;

    public GetAllWorldCommandHandler(IWorldRepository worldRepository)
    {
        _worldRepository = worldRepository;
    }

    public async Task<Result<List<World>>> Handle(GetAllWorldCommand request, CancellationToken cancellationToken)
    {
        var result = await _worldRepository.GetAllAsync(cancellationToken);

        if (result?.Any() != true)
            return Result.Failure<List<World>>(new Error(
                HttpStatusCode.NoContent,
                $"Not found any objects of world"));

        return Result.Success(result.ToList());
    }
}
