using FluentValidation;

namespace VSOP.Application.Requests.Commodities.Commands.RemoveCommodity;

internal class RemoveCommodityCommandValidator : AbstractValidator<RemoveCommodityCommand>
{
    public RemoveCommodityCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}