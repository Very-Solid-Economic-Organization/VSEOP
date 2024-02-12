using FluentValidation;
using VSOP.Application.Requests.RegionStories.Queries.GetRegionStoreById;

namespace VSOP.Application.Requests.Worlds.Queries.GetWorldById;
internal class GetRegionByIdQueryValidator : AbstractValidator<GetRegionByIdQuery>
{
    public GetRegionByIdQueryValidator()
    {
        RuleFor(x => x.Id).NotNull();
    }
}