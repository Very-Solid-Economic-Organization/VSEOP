using FluentValidation;

namespace VSOP.Application.Requests.Commodities.Commands.UpdateCommodity;

internal class UpdateCommodityCommandValidator : AbstractValidator<UpdateCommodityCommand>
{
    public UpdateCommodityCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.name).NotEmpty();
    }
}