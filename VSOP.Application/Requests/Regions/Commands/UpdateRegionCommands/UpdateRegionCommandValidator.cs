using FluentValidation;
using VSOP.Application.Requests.Worlds.Commads.CreateWorld;

namespace VSOP.Application.Requests.Regions.Commands.UpdateRegionCommands;

internal class UpdateRegionCommandValidator : AbstractValidator<UpdateRegionCommand>
{
    public UpdateRegionCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.name).NotEmpty();
    }
}