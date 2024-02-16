using VSOP.Application.Abstractions.Messaging;
using VSOP.Domain.DbModels.Commodities;
using VSOP.Domain.DbModels.Factories;
using VSOP.Domain.DbModels.Producers;

namespace VSOP.Application.Requests.Commodities.Commands.UpdateCommodity;

public sealed record UpdateProcessCommand(Guid Id, uint processesCount, string name) : ICommand<Process>;
