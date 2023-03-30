using GA_Intergado.CR2.Domain.Common.Models;
using GA_Intergado.CR2.Domain.ProductionOrders.ValueObjects;
using GA_Intergado.CR2.Domain.Recipes.Entities;
using GA_Intergado.CR2.Domain.Recipes.ValueObjects;
using GA_Intergado.CR2.Domain.Users.ValueObjects;
using System.ComponentModel.DataAnnotations.Schema;

namespace GA_Intergado.CR2.Domain.Recipes
{
    [NotMapped]
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
        public string Name { get; private set; }
        public string NameAbbreviation { get; private set; }
        public int MixTimeMinute { get; private set; }
        public int Version { get; private set; }
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

        #pragma warning disable CS8618
        public Recipe()
        {

        }

        #pragma warning restore CS8618
    }
}
