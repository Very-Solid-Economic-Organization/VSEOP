using FluentValidation;
using VSOP.Domain.DbModels.Enums;

namespace VSOP.Application.Requests.ProcessedCommodities.Commands.CreateProcessedCommodity;

internal class CreateProcessedCommodityCommandValidator : AbstractValidator<CreateProcessedCommodityCommand>
{
    public CreateProcessedCommodityCommandValidator()
    {
        RuleFor(x => x.processId).NotEmpty();
        RuleFor(x => x.commodityId).NotEmpty();
        RuleFor(x => x.processedCommodityType).Must(i => Enum.IsDefined(typeof(ProcessedCommodityType), i));
        RuleFor(x => x.quantity).NotNull().GreaterThan(0);
    }
}