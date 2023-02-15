using GA_Intergado.CR2.Domain.Common.Models;
using GA_Intergado.CR2.Domain.Ingredients.ValueObjects;
using GA_Intergado.CR2.Domain.ProductionOrders.Entities;
using GA_Intergado.CR2.Domain.ProductionOrders.ValueObjects;
using GA_Intergado.CR2.Domain.Recipes.ValueObjects;
using GA_Intergado.CR2.Domain.Users.ValueObjects;

namespace GA_Intergado.CR2.Domain.Recipes.Entities
{
    public sealed class RecipeIngredient : Entity<RecipeIngredientId>
    {
        private readonly List<ProductionOrderIngredientId> _productionOrderIngredientIds = new();
        private RecipeIngredient(RecipeIngredientId id
            , UserId modifierUserId
            , int order
            , IngredientId ingredientId
            , decimal naturalMatterPercentage
            )
            : base(id, modifierUserId)
        {
            Order = order;
            IngredientId= ingredientId;
            NaturalMatterPercentage = naturalMatterPercentage;
        }
        public IngredientId IngredientId { get; }
        public int Order { get; }
        public decimal NaturalMatterPercentage { get; }
        public IReadOnlyList<ProductionOrderIngredientId> ProductionOrderIngredientIds => _productionOrderIngredientIds.AsReadOnly();
        public static RecipeIngredient Create(
            UserId modifierUserId
            , int order
            , IngredientId ingredientId
            , decimal naturalMatterPercentage
            , RecipeIngredientId? recipeIngredientId = null
            )
        {
            return new(
               recipeIngredientId ?? RecipeIngredientId.CreateUnique()
               , modifierUserId
               , order
               , ingredientId
               , naturalMatterPercentage
               );
        }
    }
}
