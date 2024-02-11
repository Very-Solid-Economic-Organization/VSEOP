using VSOP.Application.Abstractions.Messaging;
using VSOP.Domain.DbModels.Worlds;

namespace VSOP.Application.Worlds.Queries.GetWorldById;

public sealed record GetWorldByIdQuery(Guid Id) : IQuery<World>;
