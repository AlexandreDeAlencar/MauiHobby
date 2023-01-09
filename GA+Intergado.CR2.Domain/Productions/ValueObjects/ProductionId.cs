using GA_Intergado.CR2.Domain.Common.Models;


namespace GA_Intergado.CR2.Domain.Productions.ValueObjects
{
    public sealed class ProductionId : ValueObject
    {
        public Guid Value { get; }

        private ProductionId(Guid value)
        {
            Value = value;
        }

        public static ProductionId CreateUnique()
        {
            return new ProductionId(Guid.NewGuid());
        }

        public static ProductionId Create(Guid value)
        {
            return new(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
