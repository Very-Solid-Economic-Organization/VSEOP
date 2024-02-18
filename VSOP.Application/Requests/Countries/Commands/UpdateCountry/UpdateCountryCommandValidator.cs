using FluentValidation;

namespace VSOP.Application.Requests.Countries.Commands.UpdateCountry;

internal class UpdateCountryCommandValidator : AbstractValidator<UpdateCountryCommand>
{
    public UpdateCountryCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.name).NotEmpty();
    }
}