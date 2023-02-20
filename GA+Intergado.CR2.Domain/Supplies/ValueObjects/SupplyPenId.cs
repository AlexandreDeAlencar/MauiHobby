using GA_Intergado.CR2.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA_Intergado.CR2.Domain.Supplies.ValueObjects
{
    [NotMapped]
    public sealed class SupplyPenId : ValueObject
    {
        public Guid Value { get; private set; }

        private SupplyPenId(Guid value)
        {
            Value = value;
        }

        public static SupplyPenId CreateUnique()
        {
            return new SupplyPenId(Guid.NewGuid());
        }

        public static SupplyPenId Create(Guid value)
        {
            return new(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
