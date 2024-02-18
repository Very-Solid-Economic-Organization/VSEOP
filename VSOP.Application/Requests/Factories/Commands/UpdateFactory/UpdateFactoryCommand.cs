using VSOP.Application.Abstractions.Messaging;
using VSOP.Domain.DbModels.Factories;

namespace VSOP.Application.Requests.Factories.Commands.UpdateFactory;

public sealed record UpdateFactoryCommand(Guid Id, string name) : ICommand<Factory>;
