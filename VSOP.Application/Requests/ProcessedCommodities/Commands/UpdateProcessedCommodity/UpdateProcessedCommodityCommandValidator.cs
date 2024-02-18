using FluentValidation;

namespace VSOP.Application.Requests.ProcessedCommodities.Commands.UpdateProcessedCommodity;

internal class UpdateProcessedCommodityCommandValidator : AbstractValidator<UpdateProcessedCommodityCommand>
{
    public UpdateProcessedCommodityCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.quantity).NotNull().GreaterThan(0);
    }
}