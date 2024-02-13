using FluentValidation;

namespace VSOP.Application.Requests.Worlds.Commads.UpdateWorld;

internal class UpdateWorldCommandValidator : AbstractValidator<UpdateWorldCommand>
{
    public UpdateWorldCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Name).NotEmpty();
    }
}