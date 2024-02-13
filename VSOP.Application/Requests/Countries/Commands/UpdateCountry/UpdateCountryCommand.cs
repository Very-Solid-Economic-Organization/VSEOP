using VSOP.Application.Abstractions.Messaging;
using VSOP.Domain.DbModels.Countries;

namespace VSOP.Application.Requests.Countries.Commands.CreateCountry;

public sealed record UpdateCountryCommand(Guid Id, string name) : ICommand<Country>;
