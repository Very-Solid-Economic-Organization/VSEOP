using FluentValidation;

namespace VSOP.Application.Requests.Factories.Commands.UpdateFactory;

internal class UpdateFactoryCommandValidator : AbstractValidator<UpdateFactoryCommand>
{
    public UpdateFactoryCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.name).NotEmpty();
    }
}