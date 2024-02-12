using FluentValidation;
using VSOP.Application.Requests.Worlds.Commads.CreateWorld;

namespace VSOP.Application.Requests.Regions.Commands.CreateRegionCommands;

internal class CreateRegionCommandValidator : AbstractValidator<CreateWorldCommand>
{
    public CreateRegionCommandValidator()
    {
        RuleFor(x => x.name).NotEmpty();
    }
}