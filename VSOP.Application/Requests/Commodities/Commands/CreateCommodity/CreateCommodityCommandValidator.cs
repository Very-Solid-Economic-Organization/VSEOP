using FluentValidation;

namespace VSOP.Application.Requests.Commodities.Commands.CreateCommodity;

internal class CreateCommodityCommandValidator : AbstractValidator<CreateCommodityCommand>
{
    public CreateCommodityCommandValidator()
    {
        RuleFor(x => x.WorldId).NotEmpty();
        RuleFor(x => x.name).NotEmpty();
    }
}