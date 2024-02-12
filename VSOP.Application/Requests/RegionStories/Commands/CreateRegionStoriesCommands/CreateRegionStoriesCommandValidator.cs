using FluentValidation;

namespace VSOP.Application.Requests.Worlds.Commads.CreateWorld;

internal class CreateRegionStoriesCommandValidator : AbstractValidator<CreateWorldCommand>
{
    public CreateRegionStoriesCommandValidator()
    {
        RuleFor(x => x.name).NotNull().NotEmpty();
    }
}