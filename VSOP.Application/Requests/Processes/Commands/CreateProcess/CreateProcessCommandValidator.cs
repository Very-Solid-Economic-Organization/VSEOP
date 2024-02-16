using FluentValidation;

namespace VSOP.Application.Requests.Commodities.Commands.CreateCommodity;

internal class CreateProcessCommandValidator : AbstractValidator<CreateProcessCommand>
{
    public CreateProcessCommandValidator()
    {
        RuleFor(x => x.name).NotEmpty();
    }
}