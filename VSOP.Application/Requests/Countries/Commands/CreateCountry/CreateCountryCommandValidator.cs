using FluentValidation;

namespace VSOP.Application.Requests.Countries.Commands.CreateCountry;

internal class CreateCountryCommandValidator : AbstractValidator<CreateCountryCommand>
{
    public CreateCountryCommandValidator()
    {
        RuleFor(x => x.WorldId).NotEmpty();
        RuleFor(x => x.name).NotEmpty();
    }
}