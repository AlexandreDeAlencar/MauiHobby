using GA_Intergado.CR2.Domain.DosingPlaces.ValueObjects;
using GA_Intergado.CR2.Domain.LoadingPlaces;
using GA_Intergado.CR2.Domain.ProductionOrders.ValueObjects;
using GA_Intergado.CR2.Domain.Shared.DosingPlaces;
using GA_Intergado.CR2.Domain.Users.ValueObjects;
using System.ComponentModel.DataAnnotations.Schema;

namespace GA_Intergado.CR2.Domain.DosingPlaces
{
    [NotMapped]
    public sealed class DosingPlace : LoadingPlace
    {
        private readonly List<ProductionOrderIngredientId> _productionOrderIngredientIds = new();
        private DosingPlace(DosingPlaceId id
            , UserId modifierUserId
            , string name
            , decimal minimumCapacityKg
            , decimal maximumCapacityKg
            , DosingPlaceType dosingPlaceType
            )
            : base(id, modifierUserId, id, name)
        {
            Name = name;
            MinimumCapacityKg = minimumCapacityKg;
            MaximumCapacityKg = maximumCapacityKg;
            DosingPlaceType = dosingPlaceType;
        }
        public string Name { get; private set; }
        public decimal MinimumCapacityKg { get; private set; }
        public decimal MaximumCapacityKg { get; private set; }
        public DosingPlaceType DosingPlaceType { get; private set; }
        public IReadOnlyList<ProductionOrderIngredientId> ProductionOrderIngredientIds => _productionOrderIngredientIds.AsReadOnly();

        public static DosingPlace Create(
            UserId modifierUserId
            , string name
            , decimal minimumCapacityKg
            , decimal maximumCapacityKg
            , DosingPlaceType dosingPlaceType
            , DosingPlaceId? dosingPlaceId = null
            )
        {
            return new(
               dosingPlaceId ?? DosingPlaceId.CreateUnique()
               , modifierUserId
               , name
               , minimumCapacityKg
               , maximumCapacityKg
               , dosingPlaceType
               );
        }
    }
}
