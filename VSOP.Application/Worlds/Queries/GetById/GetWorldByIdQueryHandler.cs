using System.Net;
using VSOP.Application.Abstractions.Messaging;
using VSOP.Models.DbModels.Worlds;
using VSOP.Models.Primitives;
using VSOP.Models.Primitives.Results;

namespace VSOP.Application.Worlds.Queries.GetById;

internal sealed class GetWorldByIdQueryHandler : IQueryHandler<GetWorldByIdQuery, World>
{
    public GetWorldByIdQueryHandler()
    {
        //somestuff
    }
    public async Task<Result<World>> Handle(GetWorldByIdQuery request, CancellationToken cancellationToken)
    {
        //dosomething
        //if ok
        return Result.Success(new World());

        //if not ok
        return Result.Failure(new Error(
            HttpStatusCode.BadRequest,
            "some error details"));
    }
}
