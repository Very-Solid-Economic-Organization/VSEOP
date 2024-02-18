using FluentValidation;

namespace VSOP.Application.Requests.Producers.Queries.GetProducerById;
internal class GetProducerByIdQueryValidator : AbstractValidator<GetProducerByIdQuery>
{
    public GetProducerByIdQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
