using FluentValidation;

namespace VSOP.Application.Requests.Countries.Queries.GetCountryById;
internal class GetCountryByIdQueryValidator : AbstractValidator<GetCountryByIdQuery>
{
    public GetCountryByIdQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
