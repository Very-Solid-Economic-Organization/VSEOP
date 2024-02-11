using VSOP.Application.Abstractions.Messaging;
using VSOP.Domain.DbModels.Worlds;

namespace VSOP.Application.Worlds.Queries.GetWorldList;

public sealed record GetWorldListQuery(string name = "") : IQuery<List<World>>;
