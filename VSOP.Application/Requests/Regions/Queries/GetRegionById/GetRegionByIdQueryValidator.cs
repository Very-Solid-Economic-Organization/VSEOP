using FluentValidation;

namespace VSOP.Application.Requests.Regions.Queries.GetRegionById;
internal class GetRegionByIdQueryValidator : AbstractValidator<GetRegionByIdQuery>
{
    public GetRegionByIdQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}