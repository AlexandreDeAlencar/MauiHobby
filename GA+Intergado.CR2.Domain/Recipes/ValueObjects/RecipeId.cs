using GA_Intergado.CR2.Domain.Common.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace GA_Intergado.CR2.Domain.Recipes.ValueObjects
{
    [NotMapped]
    public sealed class RecipeId : ValueObject
    {
        public Guid Value { get; private set; }

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
