using VSOP.Domain.DbModels.Producers;

namespace VSOP.Domain.DbModels.Factories;

public class Factory : Producer
{
    private Factory(Guid id, Guid regionId) : base(id, regionId)
    {
    }
}