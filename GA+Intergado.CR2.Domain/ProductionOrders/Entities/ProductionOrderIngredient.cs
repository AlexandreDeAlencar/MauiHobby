using GA_Intergado.CR2.Domain.Common.Models;
using GA_Intergado.CR2.Domain.DosingPlaces.ValueObjects;
using GA_Intergado.CR2.Domain.Loadings.ValueObjects;
using GA_Intergado.CR2.Domain.Productions.ValueObjects;
using GA_Intergado.CR2.Domain.ProductionOrders.ValueObjects;
using GA_Intergado.CR2.Domain.Recipes.ValueObjects;
using GA_Intergado.CR2.Domain.Shared.ProductionOrders;
using GA_Intergado.CR2.Domain.Users.ValueObjects;
using System.ComponentModel.DataAnnotations.Schema;

namespace GA_Intergado.CR2.Domain.ProductionOrders.Entities
{
    [NotMapped]
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
        public UserId LoaderId { get; private set; }
        public RecipeIngredientId RecipeIngredientId { get; private set; }
        public DosingPlaceId DosingPlaceId { get; private set; }
        public decimal ExpectedAmountKg { get; private set; }
        public ProductionOrderIngredientDosingType DosingType { get; private set; }
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
