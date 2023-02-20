using GA_Intergado.CR2.Domain.Common.Models;
using GA_Intergado.CR2.Domain.SupplyOrders.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA_Intergado.CR2.Domain.Users.ValueObjects
{
    [NotMapped]
    public sealed class UserId : ValueObject
    {
        public Guid Value { get; private set; }

        private UserId(Guid value)
        {
            Value = value;
        }

        public static UserId CreateUnique()
        {
            return new UserId(Guid.NewGuid());
        }

        public static UserId Create(Guid value)
        {
            return new(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
