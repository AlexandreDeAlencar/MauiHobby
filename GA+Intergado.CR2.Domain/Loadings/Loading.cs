using GA_Intergado.CR2.Domain.Common.Models;
using GA_Intergado.CR2.Domain.Common.ValueObjects;
using GA_Intergado.CR2.Domain.LoadingOrders.ValueObjects;
using GA_Intergado.CR2.Domain.Loadings.Entities;
using GA_Intergado.CR2.Domain.Loadings.ValueObjects;
using GA_Intergado.CR2.Domain.Supplies.ValueObjects;
using GA_Intergado.CR2.Domain.Users.ValueObjects;

namespace GA_Intergado.CR2.Domain.Loadings
{
    public sealed class Loading : AggregateRoot<LoadingId>
    {
        private readonly List<LoadingStep> _loadingSteps = new();
        private readonly List<SupplyId> _supplyIds = new();
        public Loading(LoadingId id
            , UserId modifierUserId
            , LoadingOrderId loadingOrderId
            , AmountKg amountKg
            , List<LoadingStep>? loadingSteps
            ) : base(id, modifierUserId)
        {
            LoadingOrderId = loadingOrderId;
            AmountKg= amountKg;
            _loadingSteps = loadingSteps;
        }
        public LoadingOrderId LoadingOrderId { get; }
        public AmountKg AmountKg { get; }
        private IReadOnlyList<LoadingStep> LoadingSteps => _loadingSteps.AsReadOnly();
        private IReadOnlyList<SupplyId> SupplyIds => _supplyIds.AsReadOnly();
        public static Loading Create(
            UserId modifierUserId
            , LoadingOrderId loadingOrderId
            , AmountKg amountKg
            , List<LoadingStep>? loadingSteps
            , LoadingId? loadingId = null
            )
        {
            return new(
                loadingId ?? LoadingId.CreateUnique()
                , modifierUserId
                , loadingOrderId
                , amountKg
                , loadingSteps
                );
        }
    }
}
