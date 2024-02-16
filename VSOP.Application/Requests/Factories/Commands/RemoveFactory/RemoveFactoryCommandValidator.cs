using FluentValidation;

namespace VSOP.Application.Requests.Factories.Commands.RemoveFactory;

internal class RemoveFactoryCommandValidator : AbstractValidator<RemoveFactoryCommand>
{
    public RemoveFactoryCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}