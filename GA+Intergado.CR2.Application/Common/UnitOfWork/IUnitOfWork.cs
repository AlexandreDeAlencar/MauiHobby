using GA_Intergado.CR2.Domain.IngredientPlaces;
using GA_Intergado.CR2.Domain.Ingredients;
using GA_Intergado.CR2.Domain.Persistence.Base;
using GA_Intergado.CR2.Domain.Recipes;

namespace GA_Intergado.CR2.App.Common.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IIngredientPlaceRepository IngredientPlaceRepository { get; }
        IIngredientRepository IngredientRepository { get; }
        IRecipeRepository ReceitaRepository { get; }

        int InsertOrUpdate(Type type, object obj);
        int Complete();
    }
}
