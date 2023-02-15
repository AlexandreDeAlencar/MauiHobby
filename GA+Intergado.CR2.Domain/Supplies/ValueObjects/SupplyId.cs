using GA_Intergado.CR2.Domain.Common.Models;

namespace GA_Intergado.CR2.Domain.Supplies.ValueObjects
{
    public sealed class SupplyId : ValueObject
    {
        public Guid Value { get; }

        private SupplyId(Guid value)
        {
            Value = value;
        }

        public static SupplyId CreateUnique()
        {
            return new SupplyId(Guid.NewGuid());
        }

        public static SupplyId Create(Guid value)
        {
            return new(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
