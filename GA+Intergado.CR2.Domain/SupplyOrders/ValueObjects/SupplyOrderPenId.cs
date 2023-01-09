using GA_Intergado.CR2.Domain.Common.Models;
using GA_Intergado.CR2.Domain.Loadings.ValueObjects;
using GA_Intergado.CR2.Domain.Supplies.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA_Intergado.CR2.Domain.SupplyOrders.ValueObjects
{
    public sealed class SupplyOrderPenId : ValueObject
    {
        public Guid Value { get; }

        private SupplyOrderPenId(Guid value)
        {
            Value = value;
        }

        public static SupplyOrderPenId CreateUnique()
        {
            return new SupplyOrderPenId(Guid.NewGuid());
        }

        public static SupplyOrderPenId Create(Guid value)
        {
            return new(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
