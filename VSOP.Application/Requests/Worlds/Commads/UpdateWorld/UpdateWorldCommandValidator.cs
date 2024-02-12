using FluentValidation;

namespace VSOP.Application.Requests.Worlds.Commads.UpdateWorld;

internal class UpdateWorldCommandValidator : AbstractValidator<UpdateWorldCommand>
{
    public UpdateWorldCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.WorldGuid).NotEmpty();
    }
}