using VSOP.Application.Abstractions.Messaging;

namespace VSOP.Application.Requests.Countries.Commands.RemoveCountry;

public sealed record RemoveCountryCommand(Guid Id) : ICommand;
