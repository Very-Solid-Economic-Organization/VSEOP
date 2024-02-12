using FluentValidation;

namespace VSOP.Application.Requests.Worlds.Commads.CreateWorld;

internal class RemoveRegionCommandValidator : AbstractValidator<CreateWorldCommand>
{
    public RemoveRegionCommandValidator()
    {
        RuleFor(x => x.name).NotNull().NotEmpty();
    }
}