using FluentValidation;

namespace VSOP.Application.Worlds.Queries.GetById;

internal class GetWorldByIdQueryValidator : AbstractValidator<GetWorldByIdQuery>
{
    public GetWorldByIdQueryValidator()
    {
        RuleFor(x => x.Id).NotNull();
    } 
}