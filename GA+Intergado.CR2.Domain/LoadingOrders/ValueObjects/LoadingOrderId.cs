using GA_Intergado.CR2.Domain.Common.Models;

namespace GA_Intergado.CR2.Domain.LoadingOrders.ValueObjects
{
    public sealed class LoadingOrderId : ValueObject
    {
        public Guid Value { get; }

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
