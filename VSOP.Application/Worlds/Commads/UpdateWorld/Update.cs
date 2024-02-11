using FluentValidation;
using VSOP.Application.Abstractions.Messaging;
using VSOP.Application.Data;
using VSOP.Domain.DbModels.Worlds;
using VSOP.Domain.Primitives.Results;
using VSOP.Persistence.Repositories;

namespace VSOP.Application.Worlds.Commads.UpdateWorld
{
    public sealed record UpdateWorldCommand(World toUpdate) : ICommand;

    internal class UpdateWorldCommandValidator : AbstractValidator<UpdateWorldCommand>
    {
        public UpdateWorldCommandValidator()
        {
            RuleFor(x => x).NotNull();
        }
    }

    internal sealed class UpdateWorldCommandHandler : ICommandHandler<UpdateWorldCommand>
    {
        private readonly IWorldRepository _worldRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateWorldCommandHandler(IWorldRepository worldRepository, IUnitOfWork unitOfWork)
        {
            _worldRepository = worldRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(UpdateWorldCommand request, CancellationToken cancellationToken)
        {
            _worldRepository.UpdateAsync(request.toUpdate, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
