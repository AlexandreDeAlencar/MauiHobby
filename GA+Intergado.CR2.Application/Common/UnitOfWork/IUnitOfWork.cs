using GA_Intergado.CR2.Domain.IngredientPlaces;
using GA_Intergado.CR2.Domain.Ingredients;
using GA_Intergado.CR2.Domain.Common.Persistence.Base;
using GA_Intergado.CR2.Domain.Recipes;
using GA_Intergado.CR2.Domain.Users;

namespace GA_Intergado.CR2.App.Common.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IIngredientPlaceRepository IngredientPlaces { get; }
        IIngredientRepository Ingredients { get; }
        IRecipeRepository Recipes { get; }
        IUserRepository Users { get; }
        public IRepositoryDefault<T> CreateRepositoryDefault<T>() where T : class, new();
        int Complete();
    }
}
