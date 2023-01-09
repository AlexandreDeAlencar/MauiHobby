using GA_Intergado.CR2.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA_Intergado.CR2.Domain.Recipes.ValueObjects
{
    public sealed class RecipeIngredientId : ValueObject
    {
        public Guid Value { get; }

        private RecipeIngredientId(Guid value)
        {
            Value = value;
        }

        public static RecipeIngredientId CreateUnique()
        {
            return new RecipeIngredientId(Guid.NewGuid());
        }

        public static RecipeIngredientId Create(Guid value)
        {
            return new(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
