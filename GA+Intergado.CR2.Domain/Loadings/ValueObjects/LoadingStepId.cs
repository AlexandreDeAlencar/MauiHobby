using GA_Intergado.CR2.Domain.Common.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace GA_Intergado.CR2.Domain.Loadings.ValueObjects
{
    [NotMapped]
    public sealed class LoadingStepId : ValueObject
    {
        public Guid Value { get; private set; }

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
