using FluentValidation;

namespace VSOP.Application.Worlds.Queries.GetById;

internal class GetWroldByIdWithCountriesQueryValidator : AbstractValidator<GetWroldByIdWithCountriesQuery>
{
    public GetWroldByIdWithCountriesQueryValidator()
    {
        RuleFor(x => x.Id).NotNull();
    } 
}