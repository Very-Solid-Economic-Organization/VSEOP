using FluentValidation;

namespace VSOP.Application.Requests.Regions.Commands.CreateRegion;

internal class CreateRegionCommandValidator : AbstractValidator<CreateRegionCommand>
{
    public CreateRegionCommandValidator()
    {
        RuleFor(x => x.countryId).NotEmpty();
        RuleFor(x => x.name).NotEmpty();
    }
}