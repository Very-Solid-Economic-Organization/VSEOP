using FluentValidation;

namespace VSOP.Application.Requests.Worlds.Commads.CreateWorld;

internal class RemoveRegionStoriesCommandValidator : AbstractValidator<CreateWorldCommand>
{
    public RemoveRegionStoriesCommandValidator()
    {
        RuleFor(x => x.name).NotEmpty(); //TODO: Узнать работает ли это.;
    }
}