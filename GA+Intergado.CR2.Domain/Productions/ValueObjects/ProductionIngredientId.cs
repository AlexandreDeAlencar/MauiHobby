using GA_Intergado.CR2.Domain.Common.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace GA_Intergado.CR2.Domain.Productions.ValueObjects
{
    [NotMapped]
    public sealed class ProductionIngredientId : ValueObject
    {
        public Guid Value { get; private set; }

        private ProductionIngredientId(Guid value)
        {
            Value = value;
        }

        public static ProductionIngredientId CreateUnique()
        {
            return new ProductionIngredientId(Guid.NewGuid());
        }

        public static ProductionIngredientId Create(Guid value)
        {
            return new(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
