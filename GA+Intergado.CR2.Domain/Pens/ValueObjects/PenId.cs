using GA_Intergado.CR2.Domain.Common.Models;

namespace GA_Intergado.CR2.Domain.Pens.ValueObjects
{
    public sealed class PenId : ValueObject
    {
        public Guid Value { get; }

        private PenId(Guid value)
        {
            Value = value;
        }

        public static PenId CreateUnique()
        {
            return new PenId(Guid.NewGuid());
        }

        public static PenId Create(Guid value)
        {
            return new(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
