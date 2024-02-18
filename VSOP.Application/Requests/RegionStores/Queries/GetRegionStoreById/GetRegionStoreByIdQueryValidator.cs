using FluentValidation;

namespace VSOP.Application.Requests.RegionStores.Queries.GetRegionStoreById;
internal class GetRegionStoreByIdQueryValidator : AbstractValidator<GetRegionStoreByIdQuery>
{
    public GetRegionStoreByIdQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}