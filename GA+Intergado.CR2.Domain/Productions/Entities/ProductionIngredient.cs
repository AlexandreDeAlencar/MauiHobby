using GA_Intergado.CR2.Domain.Common.Models;
using GA_Intergado.CR2.Domain.Common.ValueObjects;
using GA_Intergado.CR2.Domain.Productions.ValueObjects;
using GA_Intergado.CR2.Domain.ProductionOrders.ValueObjects;
using GA_Intergado.CR2.Domain.Shared.Productions;
using GA_Intergado.CR2.Domain.Users.ValueObjects;
using GA_Intergado.CR2.Domain.LoadingOrders.ValueObjects;

namespace GA_Intergado.CR2.Domain.Productions.Entities
{
    public sealed class ProductionIngredient : Entity<ProductionIngredientId>
    {
        private readonly List<LoadingOrderStepId> _loadingOrderStepIds = new();
        private ProductionIngredient(ProductionIngredientId id
            , UserId modifierUserId
            , ProductionOrderIngredientId productionOrderIngredientId
            , AmountKg amountKg
            , ProductionIngredientStep productionIngredientStep
            ) 
            : base(id, modifierUserId)
        {
            ProductionOrderIngredientId = productionOrderIngredientId;
            AmountKg = amountKg;
            ProductionIngredientStep = productionIngredientStep;
        }
        public ProductionOrderIngredientId ProductionOrderIngredientId { get; }
        public AmountKg AmountKg { get; }
        public ProductionIngredientStep ProductionIngredientStep { get; }
        public IReadOnlyList<LoadingOrderStepId> LoadingOrderStepIds => _loadingOrderStepIds.AsReadOnly();
        public static ProductionIngredient Create(
            UserId modifierUserId
            , ProductionOrderIngredientId productionOrderIngredientId
            , AmountKg amountKg
            , ProductionIngredientStep productionIngredientStep
            , ProductionIngredientId? productionIngredientId = null
            )
        {
            return new(
                productionIngredientId ?? ProductionIngredientId.CreateUnique()
                , modifierUserId
                , productionOrderIngredientId
                , amountKg
                , productionIngredientStep
                );
        }
    }
}
