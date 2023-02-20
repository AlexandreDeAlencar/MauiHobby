using GA_Intergado.CR2.Domain.Common.Models;
using GA_Intergado.CR2.Domain.IngredientPlaces.ValueObjects;
using GA_Intergado.CR2.Domain.IngredientPlaces;
using GA_Intergado.CR2.Domain.LoadingOrders.ValueObjects;
using GA_Intergado.CR2.Domain.LoadingPlaces.ValueObjects;
using GA_Intergado.CR2.Domain.Users.ValueObjects;
using System.ComponentModel.DataAnnotations.Schema;

namespace GA_Intergado.CR2.Domain.LoadingPlaces
{
    [NotMapped]
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
        public LoadingPlaceId LoadingPlaceId { get; private set; }
        public string Name { get; private set; }
        public IReadOnlyList<LoadingOrderStepId> LoadingOrderStepIds => _loadingOrderStepIds.AsReadOnly();

        #pragma warning disable CS8618
        protected LoadingPlace()
        {

        }

        #pragma warning restore CS8618
    }
}
