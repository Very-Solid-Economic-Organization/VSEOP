using FluentValidation;
using VSOP.Application.Abstractions.Messaging;
using VSOP.Application.Data;
using VSOP.Domain.DbModels.Worlds;
using VSOP.Domain.Primitives.Results;
using VSOP.Persistence.Repositories;

namespace VSOP.Application.Worlds.Commads.RemoveWorld
{
    public sealed record RemoveWorldCommand(World toRemove) : ICommand;

    internal class RemoveWorldCommandValidator : AbstractValidator<RemoveWorldCommand>
    {
        public RemoveWorldCommandValidator()
        {
            RuleFor(x => x).NotNull();
        }
    }

    internal sealed class RemoveWorldCommandHandler : ICommandHandler<RemoveWorldCommand>
    {
        private readonly IWorldRepository _worldRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RemoveWorldCommandHandler(IWorldRepository worldRepository, IUnitOfWork unitOfWork)
        {
            _worldRepository = worldRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(RemoveWorldCommand request, CancellationToken cancellationToken)
        {
            _worldRepository.UpdateAsync(request.toRemove, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
