using GA_Intergado.CR2.Domain.Common.Models;

namespace GA_Intergado.CR2.Domain.ProductionOrders.ValueObjects
{
    public sealed class ProductionOrderId : ValueObject
    {
        public Guid Value { get; }

        private ProductionOrderId(Guid value)
        {
            Value = value;
        }

        public static ProductionOrderId CreateUnique()
        {
            return new ProductionOrderId(Guid.NewGuid());
        }

        public static ProductionOrderId Create(Guid value)
        {
            return new(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
