using GA_Intergado.CR2.Domain.Common.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace GA_Intergado.CR2.Domain.LoadingOrders.ValueObjects
{
    [NotMapped]
    public sealed class LoadingOrderId : ValueObject
    {
        public Guid Value { get; private set; }

        private LoadingOrderId(Guid value)
        {
            Value = value;
        }

        public static LoadingOrderId CreateUnique()
        {
            return new LoadingOrderId(Guid.NewGuid());
        }

        public static LoadingOrderId Create(Guid value)
        {
            return new(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
