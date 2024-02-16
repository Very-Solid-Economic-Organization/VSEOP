using FluentValidation;

namespace VSOP.Application.Requests.Commodities.Queries.GetCommodityById;
internal class GetProcessByIdQueryValidator : AbstractValidator<GetProcessByIdQuery>
{
    public GetProcessByIdQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
