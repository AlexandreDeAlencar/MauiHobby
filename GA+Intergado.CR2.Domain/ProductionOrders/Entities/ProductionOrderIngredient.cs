using GA_Intergado.CR2.Domain.Common.Models;
using GA_Intergado.CR2.Domain.DosingPlaces.ValueObjects;
using GA_Intergado.CR2.Domain.Loadings.ValueObjects;
using GA_Intergado.CR2.Domain.Productions.ValueObjects;
using GA_Intergado.CR2.Domain.ProductionOrders.ValueObjects;
using GA_Intergado.CR2.Domain.Recipes.ValueObjects;
using GA_Intergado.CR2.Domain.Shared.ProductionOrders;
using GA_Intergado.CR2.Domain.Users.ValueObjects;

namespace GA_Intergado.CR2.Domain.ProductionOrders.Entities
{
    public sealed class ProductionOrderIngredient : Entity<ProductionOrderIngredientId>
    {
        private readonly List<ProductionIngredientId> _productionIngredientIds = new();
        private ProductionOrderIngredient(
            ProductionOrderIngredientId id
            , UserId modifierUserId
            , UserId loaderId
            , RecipeIngredientId recipeIngredientId
            , DosingPlaceId dosingPlaceId
            , decimal expectedAmountKg
            , ProductionOrderIngredientDosingType dosingType
            ) 
            : base(id, modifierUserId)
        {
            LoaderId = loaderId;
            RecipeIngredientId = recipeIngredientId;
            ExpectedAmountKg = expectedAmountKg;
            DosingPlaceId = dosingPlaceId;
            DosingType = dosingType;
        }
        public UserId LoaderId { get; }
        public RecipeIngredientId RecipeIngredientId { get; }
        public DosingPlaceId DosingPlaceId { get; }
        public decimal ExpectedAmountKg { get; }
        public ProductionOrderIngredientDosingType DosingType { get; }
        public IReadOnlyList<ProductionIngredientId> ProductionIngredientIds => _productionIngredientIds.AsReadOnly();
        public ProductionOrderIngredient Create(
                UserId modifierUserId
                , UserId loaderId
                , RecipeIngredientId recipeIngredientId
                , DosingPlaceId dosingPlaceId
                , decimal expectedAmountKg
                , ProductionOrderIngredientDosingType dosingType
                , ProductionOrderIngredientId? productionOrderIngredientId = null
            )
        {
            return new(
              productionOrderIngredientId ?? ProductionOrderIngredientId.CreateUnique()
              , modifierUserId
              , loaderId
              , recipeIngredientId
              , dosingPlaceId
              , expectedAmountKg
              , dosingType
              );
        }
    }
}
