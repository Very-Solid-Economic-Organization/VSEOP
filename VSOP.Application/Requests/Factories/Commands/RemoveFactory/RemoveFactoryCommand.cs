using VSOP.Application.Abstractions.Messaging;

namespace VSOP.Application.Requests.Factories.Commands.RemoveFactory;

public sealed record RemoveFactoryCommand(Guid Id) : ICommand;
