using FluentValidation;

namespace VSOP.Application.Requests.Processes.Commands.RemoveProcess;

internal class RemoveProcessCommandValidator : AbstractValidator<RemoveProcessCommand>
{
    public RemoveProcessCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}