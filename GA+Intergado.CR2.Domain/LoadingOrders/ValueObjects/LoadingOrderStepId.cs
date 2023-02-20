using GA_Intergado.CR2.Domain.Common.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace GA_Intergado.CR2.Domain.LoadingOrders.ValueObjects
{
    [NotMapped]
    public sealed class LoadingOrderStepId : ValueObject
    {
        public Guid Value { get; private set; }

        private LoadingOrderStepId(Guid value)
        {
            Value = value;
        }

        public static LoadingOrderStepId CreateUnique()
        {
            return new LoadingOrderStepId(Guid.NewGuid());
        }

        public static LoadingOrderStepId Create(Guid value)
        {
            return new(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
