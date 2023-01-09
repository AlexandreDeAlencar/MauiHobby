using GA_Intergado.CR2.Domain.Common.Models;
using GA_Intergado.CR2.Domain.LoadingOrders.ValueObjects;
using GA_Intergado.CR2.Domain.LoadingPlaces.ValueObjects;
using GA_Intergado.CR2.Domain.Users.ValueObjects;

namespace GA_Intergado.CR2.Domain.LoadingPlaces
{
    public abstract class LoadingPlace : AggregateRoot<LoadingPlaceId>
    {
        private readonly List<LoadingOrderStepId> _loadingOrderStepIds = new();
        protected LoadingPlace(LoadingPlaceId id
            , UserId modifierUserId
            , LoadingPlaceId LoadingPlaceId
            , string Name
            ) : base(id, modifierUserId)
        {
        }
        public LoadingPlaceId LoadingPlaceId { get; }
        public string Name { get; }
        public IReadOnlyList<LoadingOrderStepId> LoadingOrderStepIds => _loadingOrderStepIds.AsReadOnly();
    }
}
