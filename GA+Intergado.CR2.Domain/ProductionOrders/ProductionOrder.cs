using GA_Intergado.CR2.Domain.Common.Models;
using GA_Intergado.CR2.Domain.ProductionOrders.Entities;
using GA_Intergado.CR2.Domain.ProductionOrders.ValueObjects;
using GA_Intergado.CR2.Domain.Productions.ValueObjects;
using GA_Intergado.CR2.Domain.Recipes.ValueObjects;
using GA_Intergado.CR2.Domain.Users.ValueObjects;
using System.ComponentModel.DataAnnotations.Schema;

namespace GA_Intergado.CR2.Domain.ProductionOrders
{
    [NotMapped]
    public sealed class ProductionOrder : AggregateRoot<ProductionOrderId>
    {
        public readonly List<ProductionOrderIngredient> _productionOrderIngredients = new();
        public readonly List<ProductionId> _productionIds = new();
        private ProductionOrder(ProductionOrderId id
            , UserId modifierUserId
            , RecipeId recipeId
            , decimal expectedAmountKg
            , List<ProductionOrderIngredient>? productionOrderIngredients
            ) 
            : base(id, modifierUserId)
        {
            RecipeId = recipeId;
            ExpectedAmountKg = expectedAmountKg;
            _productionOrderIngredients = productionOrderIngredients;
        }

        public RecipeId RecipeId { get; private set; }
        public decimal ExpectedAmountKg { get; private set; }
        public IReadOnlyList<ProductionOrderIngredient> ProductionOrderIngredients => _productionOrderIngredients.AsReadOnly();
        public IReadOnlyList<ProductionId> ProductionIds => _productionIds.AsReadOnly();
        public static ProductionOrder Create(
            UserId modifierUserId
            , RecipeId recipeId
            , decimal expectedAmountKg
            , List<ProductionOrderIngredient>? productionOrderIngredients
            , ProductionOrderId? productionOrderId = null
            )
        {
            return new(
                productionOrderId ?? ProductionOrderId.CreateUnique()
                , modifierUserId
                , recipeId
                , expectedAmountKg
                , productionOrderIngredients
                );
        }
    }
}
