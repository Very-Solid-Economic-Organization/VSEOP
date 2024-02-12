using FluentValidation;
using VSOP.Application.Requests.RegionStories.Queries.GetRegionStoreById;

namespace VSOP.Application.Requests.Worlds.Queries.GetWorldById;
internal class GetRegionStoreByIdQueryValidator : AbstractValidator<GetRegionStoreByIdQuery>
{
    public GetRegionStoreByIdQueryValidator()
    {
        RuleFor(x => x.Id).NotNull();
    }
}