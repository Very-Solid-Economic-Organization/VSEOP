using FluentValidation;

namespace VSOP.Application.Requests.Countries.Commands.CreateCountry;

internal class UpdateCountryCommandValidator : AbstractValidator<UpdateCountryCommand>
{
    public UpdateCountryCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.name).NotEmpty();
    }
}