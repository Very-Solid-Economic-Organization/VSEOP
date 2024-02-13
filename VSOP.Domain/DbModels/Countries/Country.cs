﻿using System.ComponentModel.DataAnnotations;
using VSOP.Domain.DbModels.Regions;
using VSOP.Domain.DbModels.Worlds;
using VSOP.Domain.Primitives;

namespace VSOP.Domain.DbModels.Countries;

public class Country : Entity, IEquatable<Country>
{
    private Country(Guid id, string name, Guid worldId) : base(id)
    {
        Name = name;
        WorldId = worldId;
    }

    public string Name { get; set; }

    public Guid WorldId { get; private init; }

    public World World { get; private set; }

    public HashSet<Region> Regions { get; private set; } = [];

    public static Country Create(string name, Guid worldId)
    {
        if (string.IsNullOrEmpty(name))
            throw new ValidationException("Name can't be null or empty");

        if (worldId == Guid.Empty)
            throw new ValidationException("World Id can't be empty");

        return new(Guid.NewGuid(), name, worldId);
    }

    public void Update(string? name/*, Guid? worldId*/)
    {
        if (!string.IsNullOrEmpty(name))
            Name = name;

        //if (worldId != null && worldId != Guid.Empty)
        //    WorldId = worldId
    }

    public bool Equals(Country? other)
    {
        return Id == other?.Id;
    }
}