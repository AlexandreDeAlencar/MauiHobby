using GA_Intergado.CR2.Domain.Common.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace GA_Intergado.CR2.Domain.Ingredients.ValueObjects
{
    [NotMapped]
    public sealed class IngredientId : ValueObject
    {
        public Guid Value { get; private set; }

        private IngredientId(Guid value)
        {
            Value = value;
        }

        public static IngredientId CreateUnique()
        {
            return new IngredientId(Guid.NewGuid());
        }

        public static IngredientId Create(Guid value)
        {
            return new(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
