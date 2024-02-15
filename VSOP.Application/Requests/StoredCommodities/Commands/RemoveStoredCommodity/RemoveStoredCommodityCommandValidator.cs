using FluentValidation;

namespace VSOP.Application.Requests.StoredCommodities.Commands.RemoveStoredCommodity;

internal class RemoveStoredCommodityCommandValidator : AbstractValidator<RemoveStoredCommodityCommand>
{
    public RemoveStoredCommodityCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}