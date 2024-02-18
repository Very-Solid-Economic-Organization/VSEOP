using FluentValidation;

namespace VSOP.Application.Requests.Producers.Commands.AddProcess;

internal class AddProcessToProducerCommandValidator : AbstractValidator<AddProcessToProducerCommand>
{
    public AddProcessToProducerCommandValidator()
    {
        RuleFor(x => x.processId).NotEmpty();
        RuleFor(x => x.producerId).NotEmpty();
    }
}