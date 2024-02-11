using VSOP.Application.Abstractions.Messaging;
using VSOP.Domain.DbModels.Worlds;

namespace VSOP.Application.Worlds.Queries.GetById;

public sealed record GetWorldByIdQuery(Guid Id) : IQuery<World>;
