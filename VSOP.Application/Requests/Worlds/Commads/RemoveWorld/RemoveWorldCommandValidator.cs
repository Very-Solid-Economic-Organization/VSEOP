using FluentValidation;

namespace VSOP.Application.Requests.Worlds.Commads.RemoveWorld;

internal class RemoveWorldCommandValidator : AbstractValidator<RemoveWorldCommand>
{
    public RemoveWorldCommandValidator()
    {
        RuleFor(x => x.worldGuid).NotEmpty(); //TODO: Узнать работает ли это.
    }
}