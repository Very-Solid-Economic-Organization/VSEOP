using FluentValidation;

namespace VSOP.Application.Requests.Commodities.Commands.RemoveCommodity;

internal class RemoveProcessCommandValidator : AbstractValidator<RemoveProcessCommand>
{
    public RemoveProcessCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}