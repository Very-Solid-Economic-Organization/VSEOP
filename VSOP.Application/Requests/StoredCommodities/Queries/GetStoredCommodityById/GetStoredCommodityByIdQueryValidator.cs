using FluentValidation;

namespace VSOP.Application.Requests.StoredCommodities.Queries.GetStoredCommodityById;
internal class GetStoredCommodityByIdQueryValidator : AbstractValidator<GetStoredCommodityByIdQuery>
{
    public GetStoredCommodityByIdQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
