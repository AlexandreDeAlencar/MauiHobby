using GA_Intergado.CR2.Domain.Common.Models;

namespace GA_Intergado.CR2.Domain.Recipes.ValueObjects
{
    public sealed class RecipeId : ValueObject
    {
        public Guid Value { get; }

        private RecipeId(Guid value)
        {
            Value = value;
        }

        public static RecipeId CreateUnique()
        {
            return new RecipeId(Guid.NewGuid());
        }

        public static RecipeId Create(Guid value)
        {
            return new(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
