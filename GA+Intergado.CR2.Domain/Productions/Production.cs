using GA_Intergado.CR2.Domain.Common.Models;
using GA_Intergado.CR2.Domain.Common.ValueObjects;
using GA_Intergado.CR2.Domain.LoadingOrders.ValueObjects;
using GA_Intergado.CR2.Domain.ProductionOrders.ValueObjects;
using GA_Intergado.CR2.Domain.Productions.Entities;
using GA_Intergado.CR2.Domain.Productions.ValueObjects;
using GA_Intergado.CR2.Domain.Shared.Productions;
using GA_Intergado.CR2.Domain.Users.ValueObjects;

namespace GA_Intergado.CR2.Domain.Productions
{
    public sealed class Production : AggregateRoot<ProductionId>
    {
        public readonly List<ProductionIngredient> _productionIngredients = new();
        public readonly List<LoadingOrderId> _loadingOrderId = new();
        private Production(ProductionId id
            , UserId modifierUserId
            , ProductionOrderId productionOrderId
            , AmountKg amountKg
            , ProductionStep productionStep
            , List<ProductionIngredient>? productionIngredients
            )
            : base(id, modifierUserId)
        {
            ProductionOrderId = productionOrderId;
            AmountKg = amountKg;
            ProductionStep = productionStep;
            _productionIngredients = productionIngredients;
        }
        public ProductionOrderId ProductionOrderId { get; }
        public AmountKg AmountKg { get; }
        public ProductionStep ProductionStep { get; }
        public IReadOnlyList<ProductionIngredient> ProductionIngredients => _productionIngredients.AsReadOnly();
        public IReadOnlyList<LoadingOrderId> LoadingOrderIds => _loadingOrderId.AsReadOnly();
        public static Production Create(
             UserId modifierUserId
            , ProductionOrderId productionOrderId
            , AmountKg amountKg
            , ProductionStep productionStep
            , List<ProductionIngredient>? productionIngredients
            , ProductionId? productionId = null
            )
        {
            return new Production(
                productionId ?? ProductionId.CreateUnique()
                , modifierUserId
                , productionOrderId
                , amountKg
                , productionStep
                , productionIngredients
                );
        }

    }
}
