using GA_Intergado.CR2.Domain.Common.Models;
using GA_Intergado.CR2.Domain.LoadingOrders.ValueObjects;
using GA_Intergado.CR2.Domain.LoadingPlaces.ValueObjects;
using GA_Intergado.CR2.Domain.Loadings.ValueObjects;
using GA_Intergado.CR2.Domain.Productions.ValueObjects;
using GA_Intergado.CR2.Domain.Users.ValueObjects;

namespace GA_Intergado.CR2.Domain.LoadingOrders.Entities
{
    public sealed class LoadingOrderStep : Entity<LoadingOrderStepId>
    {
        private readonly List<ProductionIngredientId> _productionIngredientIds = new();
        private readonly List<LoadingStepId> _loadingStepIds = new();

        private LoadingOrderStep(LoadingOrderStepId id
            , UserId modifierUserId
            , LoadingPlaceId loadingPlaceId
            , decimal expectedAmountKg
            , List<ProductionIngredientId>? productionIngredientIds
            )
            : base(id, modifierUserId)
        {
            LoadingPlaceId = loadingPlaceId;
            ExpectedAmountKg = expectedAmountKg;
            _productionIngredientIds = productionIngredientIds;
        }
        public LoadingPlaceId LoadingPlaceId { get; }
        public decimal ExpectedAmountKg { get; }
        public IReadOnlyList<ProductionIngredientId> ProductionIngredientIds => _productionIngredientIds.AsReadOnly();
        public IReadOnlyList<LoadingStepId> LoadingStepIds => _loadingStepIds.AsReadOnly();
        public static LoadingOrderStep Create(
            UserId modifierUserId
            , LoadingPlaceId loadingPlaceId
            , decimal expectedAmountKg
            , List<ProductionIngredientId>? productionIngredientIds
            , LoadingOrderStepId? loadingOrderStepId = null
            )
        {
            return new LoadingOrderStep(
                loadingOrderStepId ?? LoadingOrderStepId.CreateUnique()
                , modifierUserId
                , loadingPlaceId
                , expectedAmountKg
                , productionIngredientIds
                );
        }
    }
}
