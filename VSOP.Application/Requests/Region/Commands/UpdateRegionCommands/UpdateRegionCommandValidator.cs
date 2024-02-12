using FluentValidation;

namespace VSOP.Application.Requests.Worlds.Commads.CreateWorld;

internal class UpdateRegionCommandValidator : AbstractValidator<CreateWorldCommand>
{
    public UpdateRegionCommandValidator()
    {
        RuleFor(x => x.name).NotNull().NotEmpty();
    }
}