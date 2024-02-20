using FluentValidation;

namespace VSOP.Application.Requests.Processes.Commands.UpdateProcess;

internal class UpdateProcessCommandValidator : AbstractValidator<UpdateProcessCommand>
{
    public UpdateProcessCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.name).NotEmpty();
        RuleFor(x => x.processTickrate).NotEmpty();
    }
}