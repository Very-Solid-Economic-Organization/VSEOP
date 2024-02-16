using VSOP.Application.Abstractions.Messaging;
using VSOP.Domain.DbModels.Producers;

namespace VSOP.Application.Requests.Commodities.Commands.CreateCommodity;

public sealed record CreateProcessCommand(uint processesCount, string name) : ICommand<Process>;
