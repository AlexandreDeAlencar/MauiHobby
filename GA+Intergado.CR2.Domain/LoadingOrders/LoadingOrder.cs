using GA_Intergado.CR2.Domain.Common.Models;
using GA_Intergado.CR2.Domain.LoadingOrders.Entities;
using GA_Intergado.CR2.Domain.LoadingOrders.ValueObjects;
using GA_Intergado.CR2.Domain.Loadings.ValueObjects;
using GA_Intergado.CR2.Domain.Productions.ValueObjects;
using GA_Intergado.CR2.Domain.Users.ValueObjects;

namespace GA_Intergado.CR2.Domain.LoadingOrders
{
    public sealed class LoadingOrder : AggregateRoot<LoadingOrderStepId>
    {
        private readonly List<LoadingOrderStep> _loadingOrderSteps = new();
        private readonly List<LoadingId> _loadingIds = new();
        private LoadingOrder(
            LoadingOrderStepId id
            , UserId modifierUserId
            , decimal expectedAmountKg
            , ProductionId productionId
            , List<LoadingOrderStep>? loadingOrderSteps
            )
            : base(id, modifierUserId)
        {
            ExapectedAmountKg = expectedAmountKg;
            ProductionId = productionId;
            _loadingOrderSteps = loadingOrderSteps;
        }
        public decimal ExapectedAmountKg { get; }
        public ProductionId ProductionId { get; }
        private IReadOnlyList<LoadingOrderStep> LoadingOrderSteps => _loadingOrderSteps.AsReadOnly();
        private IReadOnlyList<LoadingId> LoadingIds => _loadingIds.AsReadOnly();
        public static LoadingOrder Create(
            UserId modifierUserId
            , decimal expectedAmountKg
            , ProductionId productionId
            , List<LoadingOrderStep>? loadingOrderSteps
            , LoadingOrderStepId? loadingOrderStepId = null
            )
        {
            return new(
                loadingOrderStepId ?? LoadingOrderStepId.CreateUnique()
                , modifierUserId
                , expectedAmountKg
                , productionId
                , loadingOrderSteps
                );
        }
    }
}
