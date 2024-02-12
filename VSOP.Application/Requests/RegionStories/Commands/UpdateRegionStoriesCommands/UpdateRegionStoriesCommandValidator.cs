using FluentValidation;

namespace VSOP.Application.Requests.Worlds.Commads.CreateWorld;

internal class UpdateRegionStoriesCommandValidator : AbstractValidator<CreateWorldCommand>
{
    public UpdateRegionStoriesCommandValidator()
    {
        RuleFor(x => x.name).NotNull().NotEmpty();
    }
}