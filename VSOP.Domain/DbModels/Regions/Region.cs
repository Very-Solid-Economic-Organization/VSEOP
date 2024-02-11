using System.ComponentModel.DataAnnotations;
using VSOP.Domain.DbModels.Factories;
using VSOP.Domain.Primitives;

namespace VSOP.Domain.DbModels.Regions;

public class Region : Entity, IEquatable<Region>
{
    public Region(Guid id, string name, Guid countryId, Guid regionStoreId) : base(id)
    {
        Name = name;
        CountryId = countryId;
        RegionStoreId = regionStoreId;
    }

    public string Name { get; private set; }

    public Guid CountryId { get; private set; }

    public Guid RegionStoreId { get; private init; }

    public List<Producer> Producers { get; private set; } = new();

    public static Region Create(string name, Guid countryId, Guid regionStoreId)
    {
        if (string.IsNullOrEmpty(name))
            throw new ValidationException("Name can't be null or empty");

        if (countryId == Guid.Empty)
            throw new ValidationException("Empty countryId is not allowed");

        if (regionStoreId == Guid.Empty)
            throw new ValidationException("Empty regionStoreId is not allowed");

        return new Region(Guid.NewGuid(), name, countryId, regionStoreId);
    }

    public bool Equals(Region? other)
    {
        return Id == other?.Id;
    }
}