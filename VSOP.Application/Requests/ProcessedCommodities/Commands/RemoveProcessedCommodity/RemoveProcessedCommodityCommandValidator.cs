using FluentValidation;

namespace VSOP.Application.Requests.ProcessedCommodities.Commands.RemoveProcessedCommodity;

internal class RemoveProcessedCommodityCommandValidator : AbstractValidator<RemoveProcessedCommodityCommand>
{
    public RemoveProcessedCommodityCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}