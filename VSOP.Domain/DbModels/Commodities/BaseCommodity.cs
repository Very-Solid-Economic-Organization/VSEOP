using System.ComponentModel.DataAnnotations;
using VSOP.Models.Primitives;

namespace VSOP.Models.DbModels.Comodities
{
    public class BaseCommodity : Entity, IEquatable<BaseCommodity>
    {
        public BaseCommodity(Guid id, string name) : base(id)
        {
            Name = name;
        }

        public string Name { get; private init; }

        public static BaseCommodity Create(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ValidationException("Name can't be null or empty");

            return new(Guid.NewGuid(), name);
        }
        public bool Equals(BaseCommodity? other)
        {
            return Id == other?.Id;
        }
    }
}
