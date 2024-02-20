using FluentValidation;

namespace VSOP.Application.Requests.ProducerProcesses.Queries.GetProducerProcess;
internal class GetProducerProcessByIdQueryValidator : AbstractValidator<GetProducerProcessByIdQuery>
{
    public GetProducerProcessByIdQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}