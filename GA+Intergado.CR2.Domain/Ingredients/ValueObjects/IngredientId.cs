using GA_Intergado.CR2.Domain.Common.Models;

namespace GA_Intergado.CR2.Domain.Ingredients.ValueObjects
{
    public sealed class IngredientId : ValueObject
    {
        public Guid Value { get; }

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
