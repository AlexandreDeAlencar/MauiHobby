using GA_Intergado.CR2.Domain.Common.Models;
using GA_Intergado.CR2.Domain.ProductionOrders.ValueObjects;
using GA_Intergado.CR2.Domain.Recipes.Entities;
using GA_Intergado.CR2.Domain.Recipes.ValueObjects;
using GA_Intergado.CR2.Domain.Users.ValueObjects;

namespace GA_Intergado.CR2.Domain.Recipes
{
    public sealed class Recipe : AggregateRoot<RecipeId>
    {
        private readonly List<RecipeIngredient> _recipeIngredients = new();
        private readonly List<ProductionOrderId> _productionOrderIds = new();
        private Recipe(RecipeId id
          , UserId modifierUserId
           , string name
           , string nameAbbreviation
           , int version
           , int mixTimeMinute
           , List<RecipeIngredient>? recipeIngredients
           )
           : base(id, modifierUserId)
        {
            Name = name;
            MixTimeMinute = mixTimeMinute;
            NameAbbreviation = nameAbbreviation;
            Version = version;
            _recipeIngredients = recipeIngredients;
        }
        public string Name { get; }
        public string NameAbbreviation { get; }
        public int MixTimeMinute { get; }
        public int Version { get; }
        public IReadOnlyList<RecipeIngredient> RecipeIngredients => _recipeIngredients.AsReadOnly();
        public IReadOnlyList<ProductionOrderId> ProductionOrderIds => _productionOrderIds.AsReadOnly();
        public static Recipe Create(
            UserId modifierUserId
           , string name
           , string nameAbbreviation
           , int mixTimeMinute
           , List<RecipeIngredient>? recipeIngredients
           , RecipeId? recipeId = null
           , int version = 1
           )
        {
            return new(
               recipeId ?? RecipeId.CreateUnique()
               , modifierUserId
               , name
               , nameAbbreviation
               , version
               , mixTimeMinute
               , recipeIngredients
                );
        }
    }
}
