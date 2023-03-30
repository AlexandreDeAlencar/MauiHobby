using GA_Intergado.CR2.App.Common.UnitOfWork;
using GA_Intergado.CR2.Domain.Common.Persistence.Base;
using GA_Intergado.CR2.Domain.IngredientPlaces;
using GA_Intergado.CR2.Domain.Ingredients;
using GA_Intergado.CR2.Domain.Recipes;
using GA_Intergado.CR2.Domain.Recipes.ValueObjects;
using GA_Intergado.CR2.Domain.Users;
using GA_Intergado.CR2.EntityFrameworkCore.Persistence.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace GA_Intergado.CR2.EntityFrameworkCore.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private MyDbContext _context;

        public IIngredientPlaceRepository IngredientPlaces { get; private set; }

        public IIngredientRepository Ingredients { get; private set; }

        public IRecipeRepository Recipes { get; private set; }

        public IUserRepository Users { get; private set; }

        public UnitOfWork(MyDbContext context
            , IIngredientPlaceRepository ingredientPlaces
            , IIngredientRepository ingredients
            , IRecipeRepository recipes
            , IUserRepository users
            )
        {
            _context = context;
            IngredientPlaces = ingredientPlaces;
            Ingredients = ingredients;
            Recipes = recipes;
            Users = users;
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public IRepositoryDefault<T> CreateRepositoryDefault<T>() where T : class, new()
        {
            return new RespositoryDefault<T>(_context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
