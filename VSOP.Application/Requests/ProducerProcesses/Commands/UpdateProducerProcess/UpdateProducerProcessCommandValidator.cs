using FluentValidation;

namespace VSOP.Application.Requests.ProducerProcesses.Commands.UpdateProducerProcess;

internal class UpdateProducerProcessCommandValidator : AbstractValidator<UpdateProducerProcessCommand>
{
    public UpdateProducerProcessCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}