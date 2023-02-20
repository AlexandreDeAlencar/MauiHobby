using GA_Intergado.CR2.Domain.LoadingPlaces.ValueObjects;
using GA_Intergado.CR2.Domain.Shared.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace GA_Intergado.CR2.Domain.IngredientPlaces.ValueObjects
{
    [NotMapped]
    public sealed class IngredientPlaceId : LoadingPlaceId
    {
        public Guid Value { get; private set; }

        private IngredientPlaceId(Guid value) : base(value, LoadingPlaceType.IngredientPlace)
        {
            Value = value;
        }

        public static IngredientPlaceId CreateUnique()
        {
            return new IngredientPlaceId(Guid.NewGuid());
        }

        public static IngredientPlaceId Create(Guid value)
        {
            return new(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
