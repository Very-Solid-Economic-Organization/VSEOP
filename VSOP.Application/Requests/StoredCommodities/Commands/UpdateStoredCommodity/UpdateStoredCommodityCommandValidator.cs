using FluentValidation;

namespace VSOP.Application.Requests.StoredCommodities.Commands.UpdateStoredCommodity;

internal class UpdateStoredCommodityCommandValidator : AbstractValidator<UpdateStoredCommodityCommand>
{
    public UpdateStoredCommodityCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.quantity).NotNull().GreaterThanOrEqualTo(0);
        RuleFor(x => x.currentDemand).IsInEnum();
    }
}