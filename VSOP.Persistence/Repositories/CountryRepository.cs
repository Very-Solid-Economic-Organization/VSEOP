using VSOP.Domain.DbModels.Countries;

namespace VSOP.Persistence.Repositories;

internal class CountryRepository : Repository<Country>, ICountryRepository
{
    public CountryRepository(VSEOPContext context) : base(context)
    {
    }

    //public IEnumerable<World> Where(Guid id)
    //{
    //    return _context.Where(x => x.Id == id).Include(x => x.Countries);
    //}
}