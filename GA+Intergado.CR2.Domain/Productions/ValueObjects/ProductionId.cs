using GA_Intergado.CR2.Domain.Common.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace GA_Intergado.CR2.Domain.Productions.ValueObjects
{
    [NotMapped]
    public sealed class ProductionId : ValueObject
    {
        public Guid Value { get; private set; }

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
