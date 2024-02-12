using FluentValidation;

namespace VSOP.Application.Requests.Worlds.Commads.CreateWorld;

internal class CreateWorldCommandValidator : AbstractValidator<CreateWorldCommand>
{
    public CreateWorldCommandValidator()
    {
        RuleFor(x => x.name).NotEmpty();
    }
}