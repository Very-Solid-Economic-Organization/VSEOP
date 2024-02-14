using FluentValidation;
using VSOP.Application.Requests.Worlds.Commads.CreateWorld;

namespace VSOP.Application.Requests.Regions.Commands.CreateRegion;

internal class CreateRegionCommandValidator : AbstractValidator<CreateRegionCommand>
{
    public CreateRegionCommandValidator()
    {
        RuleFor(x => x.countryId).NotEmpty();
        RuleFor(x => x.name).NotEmpty();
    }
}