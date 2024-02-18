using FluentValidation;

namespace VSOP.Application.Requests.ProcessedCommodities.Queries.GetProcessedCommodityById;
internal class GetProcessedCommodityByIdQueryValidator : AbstractValidator<GetProcessedCommodityByIdQuery>
{
    public GetProcessedCommodityByIdQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
