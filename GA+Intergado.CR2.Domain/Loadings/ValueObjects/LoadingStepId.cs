using GA_Intergado.CR2.Domain.Common.Models;

namespace GA_Intergado.CR2.Domain.Loadings.ValueObjects
{
    public sealed class LoadingStepId : ValueObject
    {
        public Guid Value { get; }

        private LoadingStepId(Guid value)
        {
            Value = value;
        }

        public static LoadingStepId CreateUnique()
        {
            return new LoadingStepId(Guid.NewGuid());
        }

        public static LoadingStepId Create(Guid value)
        {
            return new(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
