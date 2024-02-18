using FluentValidation;
using VSOP.Domain.DbModels.Enums;

namespace VSOP.Application.Requests.StoredCommodities.Commands.CreateStoredCommodity;

internal class CreateStoredCommodityCommandValidator : AbstractValidator<CreateStoredCommodityCommand>
{
    public CreateStoredCommodityCommandValidator()
    {
        RuleFor(x => x.commodityId).NotEmpty();
        RuleFor(x => x.quantity).NotNull().GreaterThanOrEqualTo(0);
        RuleFor(x => x.selfCost).NotNull();
        RuleFor(x => x.price).NotNull();
        RuleFor(x => x.currentDemand).Must(i => Enum.IsDefined(typeof(Demand), i));

    }
}