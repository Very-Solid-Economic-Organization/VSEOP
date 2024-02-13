using System.ComponentModel.DataAnnotations;
using VSOP.Domain.DbModels.Countries;
using VSOP.Domain.DbModels.Factories;
using VSOP.Domain.DbModels.Producers;
using VSOP.Domain.Primitives;

namespace VSOP.Domain.DbModels.Regions;

public class Region : Entity, IEquatable<Region>
{
    private Region(Guid id, string name, Guid countryId) : base(id)
    {
        Name = name;
        CountryId = countryId;
        RegionStore = RegionStore.Create(id);
        RegionStoreId = RegionStore.Id;
    }

    public string Name { get; private set; }

    public Guid CountryId { get; private set; }

    public Country Country { get; private set; }

    public Guid RegionStoreId { get; private init; }

    public RegionStore RegionStore { get; private set; }

    public HashSet<Factory> Factories { get; private set; } = new();

    public static Region Create(string name, Guid countryId)
    {
        if (string.IsNullOrEmpty(name))
            throw new ValidationException("Name can't be null or empty");

        if (countryId == Guid.Empty)
            throw new ValidationException("Empty countryId is not allowed");

        return new Region(Guid.NewGuid(), name, countryId);
    }

    public bool Equals(Region? other)
    {
        return Id == other?.Id;
    }
}