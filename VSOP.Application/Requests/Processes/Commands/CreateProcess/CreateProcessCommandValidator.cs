using FluentValidation;

namespace VSOP.Application.Requests.Processes.Commands.CreateProcess;

internal class CreateProcessCommandValidator : AbstractValidator<CreateProcessCommand>
{
    public CreateProcessCommandValidator()
    {
        RuleFor(x => x.name).NotEmpty();
        RuleFor(x => x.processesCount).NotEmpty();
    }
}