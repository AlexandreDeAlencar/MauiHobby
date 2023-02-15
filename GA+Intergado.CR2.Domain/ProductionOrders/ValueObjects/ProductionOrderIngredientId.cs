using GA_Intergado.CR2.Domain.Common.Models;

namespace GA_Intergado.CR2.Domain.ProductionOrders.ValueObjects
{
    public sealed class ProductionOrderIngredientId : ValueObject
    {
        public Guid Value { get; }

        private ProductionOrderIngredientId(Guid value)
        {
            Value = value;
        }

        public static ProductionOrderIngredientId CreateUnique()
        {
            return new ProductionOrderIngredientId(Guid.NewGuid());
        }

        public static ProductionOrderIngredientId Create(Guid value)
        {
            return new(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
