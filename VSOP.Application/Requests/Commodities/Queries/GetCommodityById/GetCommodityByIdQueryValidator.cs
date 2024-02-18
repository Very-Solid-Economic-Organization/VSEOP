using FluentValidation;

namespace VSOP.Application.Requests.Commodities.Queries.GetCommodityById;
internal class GetCommodityByIdQueryValidator : AbstractValidator<GetCommodityByIdQuery>
{
    public GetCommodityByIdQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
