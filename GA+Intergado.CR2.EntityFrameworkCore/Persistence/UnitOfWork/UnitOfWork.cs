using GA_Intergado.CR2.App.Common.UnitOfWork;
using GA_Intergado.CR2.Domain.IngredientPlaces;
using GA_Intergado.CR2.Domain.Ingredients;
using GA_Intergado.CR2.Domain.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA_Intergado.CR2.EntityFrameworkCore.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public IIngredientPlaceRepository IngredientPlaceRepository => throw new NotImplementedException();

        public IIngredientRepository IngredientRepository => throw new NotImplementedException();

        public IRecipeRepository ReceitaRepository => throw new NotImplementedException();

        public int Complete()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public int InsertOrUpdate(Type type, object obj)
        {
            throw new NotImplementedException();
        }
    }
}
