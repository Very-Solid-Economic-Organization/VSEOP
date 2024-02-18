using FluentValidation;

namespace VSOP.Application.Requests.Factories.Commands.CreateFactory;

internal class CreateFactoryCommandValidator : AbstractValidator<CreateFactoryCommand>
{
    public CreateFactoryCommandValidator()
    {
        RuleFor(x => x.RegionId).NotEmpty();
        RuleFor(x => x.name).NotEmpty();
    }
}