using GA_Intergado.CR2.Domain.IngredientPlaces.ValueObjects;
using GA_Intergado.CR2.Domain.Ingredients.ValueObjects;
using GA_Intergado.CR2.Domain.LoadingPlaces;
using GA_Intergado.CR2.Domain.Users.ValueObjects;

namespace GA_Intergado.CR2.Domain.IngredientPlaces
{
    public sealed class IngredientPlace : LoadingPlace
    {
        private readonly List<IngredientId> _ingredientIds = new();
        private IngredientPlace(IngredientPlaceId id
            , UserId modifierUserId
            , string name
            ) : base(id, modifierUserId, id, name)
        {
            Name = name;
        }
        public string Name { get; }
        public IReadOnlyList<IngredientId> IngredientIds => _ingredientIds.AsReadOnly();
        public static IngredientPlace Create(
             UserId modifierUserId
            , string name
            , IngredientPlaceId? ingredientPlaceId = null
            )
        {
            return new(
                ingredientPlaceId ?? IngredientPlaceId.CreateUnique()
                , modifierUserId
                , name
                );
        }
    }
}
