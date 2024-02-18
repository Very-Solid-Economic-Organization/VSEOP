using FluentValidation;

namespace VSOP.Application.Requests.Factories.Queries.GetFactoryById;
internal class GetFactoryByIdQueryValidator : AbstractValidator<GetFactoryByIdQuery>
{
    public GetFactoryByIdQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
