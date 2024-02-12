using FluentValidation;

namespace VSOP.Application.Requests.Worlds.Queries.GetWorldById;
internal class GetWorldByIdQueryValidator : AbstractValidator<GetWorldByIdQuery>
{
    public GetWorldByIdQueryValidator()
    {
        RuleFor(x => x.Id).NotNull();
    }
}