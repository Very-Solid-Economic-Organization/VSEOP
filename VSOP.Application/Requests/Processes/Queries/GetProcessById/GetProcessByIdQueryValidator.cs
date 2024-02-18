using FluentValidation;

namespace VSOP.Application.Requests.Processes.Queries.GetProcessById;
internal class GetProcessByIdQueryValidator : AbstractValidator<GetProcessByIdQuery>
{
    public GetProcessByIdQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
