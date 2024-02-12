using FluentValidation;

namespace VSOP.Application.Requests.Worlds.Commads.CreateWorld;

internal class CreateRegionCommandValidator : AbstractValidator<CreateWorldCommand>
{
    public CreateRegionCommandValidator()
    {
        RuleFor(x => x.name).NotNull().NotEmpty();
    }
}