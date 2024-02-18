using FluentValidation;

namespace VSOP.Application.Requests.Regions.Commands.RemoveRegion;

internal class RemoveRegionCommandValidator : AbstractValidator<RemoveRegionCommand>
{
    public RemoveRegionCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}