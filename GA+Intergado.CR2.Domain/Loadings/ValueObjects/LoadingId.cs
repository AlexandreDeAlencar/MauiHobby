using GA_Intergado.CR2.Domain.Common.Models;

namespace GA_Intergado.CR2.Domain.Loadings.ValueObjects
{
    public sealed class LoadingId : ValueObject
    {
        public Guid Value { get; }

        private LoadingId(Guid value)
        {
            Value = value;
        }

        public static LoadingId CreateUnique()
        {
            return new LoadingId(Guid.NewGuid());
        }

        public static LoadingId Create(Guid value)
        {
            return new(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
