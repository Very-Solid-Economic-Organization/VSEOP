using FluentValidation;
using VSOP.Domain.DbModels.Enums;

namespace VSOP.Application.Requests.StoredCommodities.Commands.UpdateStoredCommodity;

internal class UpdateStoredCommodityCommandValidator : AbstractValidator<UpdateStoredCommodityCommand>
{
    public UpdateStoredCommodityCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();

        RuleFor(x => x).Must(x => x.quantity != null || x.selfCost != null || x.price != null || x.currentDemand != null);

        RuleFor(x => x.quantity).NotEmpty().When(x => x.quantity != null);
        RuleFor(x => x.selfCost).NotEmpty().When(x => x.selfCost != null);
        RuleFor(x => x.price).NotEmpty().When(x => x.price != null);
        RuleFor(x => x.currentDemand).Must(i => Enum.IsDefined(typeof(Demand), i)).When(x => x.currentDemand != null);
    }
}