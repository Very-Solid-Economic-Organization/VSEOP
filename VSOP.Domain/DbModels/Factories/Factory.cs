using System.ComponentModel.DataAnnotations;
using VSOP.Domain.DbModels.Producers;

namespace VSOP.Domain.DbModels.Factories;

public class Factory : Producer
{
    private Factory(Guid id, Guid regionId, string name) : base(id, regionId, name)
    {
    }

    public Factory Create(Guid regionId, string name)
    {
        if (regionId == Guid.Empty)
            throw new ValidationException("Region Id can't be empty");

        if (string.IsNullOrEmpty(name))
            throw new ValidationException("Name can't be null or empty");

        return new Factory(Guid.NewGuid(), regionId, name);
    }
}