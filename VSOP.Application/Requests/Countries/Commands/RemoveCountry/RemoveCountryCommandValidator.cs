using FluentValidation;

namespace VSOP.Application.Requests.Countries.Commands.CreateCountry;

internal class RemoveCountryCommandValidator : AbstractValidator<RemoveCountryCommand>
{
    public RemoveCountryCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}