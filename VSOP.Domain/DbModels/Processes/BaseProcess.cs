﻿using System.ComponentModel.DataAnnotations;
using VSOP.Models.DbModels.Comodities;
using VSOP.Models.DbModels.Countries;
using VSOP.Models.Primitives;

namespace VSOP.Models.DbModels.Processes
{
    public class BaseProcess : Entity, IEquatable<BaseProcess>
    {
        public BaseProcess(Guid id, Guid factoryId) : base(id)
        {
            FactoryId = factoryId;
        }

        public int ProcessesCount { get; set; } = 0;

        public Guid FactoryId { get; private init; }

        public List<BaseCommodity> ConsumingCommodities { get; set; } = [];

        public List<BaseCommodity> ProducedCommodities { get; set; } = [];

        public static BaseProcess Create(Guid factoryId)
        {
            if (factoryId == Guid.Empty)
                throw new ValidationException("Factory Id can't be empty");

            return new(Guid.NewGuid(), factoryId);
        }

        public bool Equals(BaseProcess? other)
        {
            return Id == other?.Id;
        }
    }
}
