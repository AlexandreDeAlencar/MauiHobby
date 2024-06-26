﻿using GA_Intergado.CR2.Domain.Common.Models;
using GA_Intergado.CR2.Domain.Ingredients.ValueObjects;
using GA_Intergado.CR2.Domain.IngredientPlaces.ValueObjects;
using GA_Intergado.CR2.Domain.Shared.Ingredients;
using GA_Intergado.CR2.Domain.Users.ValueObjects;
using GA_Intergado.CR2.Domain.Recipes.ValueObjects;

namespace GA_Intergado.CR2.Domain.Ingredients
{
    public sealed class Ingredient : AggregateRoot<IngredientId>
    {
        private List<RecipeIngredientId> _recipeIngredientIds = new();
        private Ingredient(IngredientId id
            , UserId modifierUserId
            , string name
            , decimal dryMatterPercentage
            , IngredientPlaceId placeId
            , IngredientType ingredientType
            )
            : base(id, modifierUserId)
        {
            Name = name;
            DryMatterPercentage = dryMatterPercentage;
            PlaceId = placeId;
            IngredientType = ingredientType;
        }
        public string Name { get; private set; }
        public string NameAbbreviation { get; private set; }
        public decimal DryMatterPercentage { get; private set; }
        public IngredientPlaceId PlaceId { get; private set; } 
        public IngredientType IngredientType { get; private set; }
        public IReadOnlyList<RecipeIngredientId> RecipeIngredientIds => _recipeIngredientIds.AsReadOnly();
        public static Ingredient Create(
            UserId modifierUserId
            , string name
            , decimal dryMatterPercentage
            , IngredientPlaceId placeId
            , IngredientType ingredientType
            , IngredientId? ingredientId = null
            )
        {
            return new(
                ingredientId ?? IngredientId.CreateUnique()
                , modifierUserId
                , name
                , dryMatterPercentage
                , placeId
                , ingredientType
                );
        }

        #pragma warning disable CS8618
        protected Ingredient()
        {

        }

        #pragma warning restore CS8618
    }
}
