using VSOP.Application.Abstractions.Messaging;
using VSOP.Domain.DbModels.Factories;

namespace VSOP.Application.Requests.Factories.Commands.CreateFactory;

public sealed record CreateFactoryCommand(Guid RegionId, string name) : ICommand<Factory>;
