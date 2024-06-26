﻿using GA_Intergado.CR2.Domain.Common.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace GA_Intergado.CR2.Domain.SupplyOrders.ValueObjects
{
    [NotMapped]
    public sealed class SupplyOrderId : ValueObject
    {
        public Guid Value { get; private set; }

        private SupplyOrderId(Guid value)
        {
            Value = value;
        }

        public static SupplyOrderId CreateUnique()
        {
            return new SupplyOrderId(Guid.NewGuid());
        }

        public static SupplyOrderId Create(Guid value)
        {
            return new(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
