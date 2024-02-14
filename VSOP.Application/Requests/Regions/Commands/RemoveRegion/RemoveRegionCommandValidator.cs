using FluentValidation;
using VSOP.Application.Requests.Worlds.Commads.CreateWorld;

namespace VSOP.Application.Requests.Regions.Commands.RemoveRegion;

internal class RemoveRegionCommandValidator : AbstractValidator<RemoveRegionCommand>
{
    public RemoveRegionCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}