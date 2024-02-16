using FluentValidation;

namespace VSOP.Application.Requests.Commodities.Commands.UpdateCommodity;

internal class UpdateProcessCommandValidator : AbstractValidator<UpdateProcessCommand>
{
    public UpdateProcessCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.name).NotEmpty();
    }
}