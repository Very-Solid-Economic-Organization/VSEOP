using FluentValidation;

namespace VSOP.Application.Requests.ProducerProcesses.Commands.CreateProducerProcess;

internal class CreateProducerProcessCommandValidator : AbstractValidator<CreateProducerProcessCommand>
{
    public CreateProducerProcessCommandValidator()
    {
        RuleFor(x => x.processId).NotEmpty();
        RuleFor(x => x.producerId).NotEmpty();
    }
}