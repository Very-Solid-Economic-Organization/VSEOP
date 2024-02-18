using FluentValidation;

namespace VSOP.Application.Requests.Countries.Commands.RemoveCountry;

internal class RemoveCountryCommandValidator : AbstractValidator<RemoveCountryCommand>
{
    public RemoveCountryCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}