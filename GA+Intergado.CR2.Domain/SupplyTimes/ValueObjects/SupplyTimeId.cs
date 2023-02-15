using GA_Intergado.CR2.Domain.Common.Models;

namespace GA_Intergado.CR2.Domain.SupplyTimes.ValueObjects
{
    public sealed class SupplyTimeId : ValueObject
    {
        public Guid Value { get; }

        private SupplyTimeId(Guid value)
        {
            Value = value;
        }

        public static SupplyTimeId CreateUnique()
        {
            return new SupplyTimeId(Guid.NewGuid());
        }

        public static SupplyTimeId Create(Guid value)
        {
            return new(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
