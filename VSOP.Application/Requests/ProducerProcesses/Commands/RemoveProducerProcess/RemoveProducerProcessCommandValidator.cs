using FluentValidation;

namespace VSOP.Application.Requests.ProducerProcesses.Commands.RemoveProducerProcess;

internal class RemoveProducerProcessCommandValidator : AbstractValidator<RemoveProducerProcessCommand>
{
    public RemoveProducerProcessCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}