using GA_Intergado.CR2.Domain.IngredientPlaces;
using GA_Intergado.CR2.Domain.Persistence.Base;
using GA_Intergado.CR2.Domain.Recipes;
using GA_Intergado.CR2.EntityFrameworkCore.Persistence.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA_Intergado.CR2.EntityFrameworkCore.Persistence.Repository
{
    public class RecipeRepository : RespositoryDefault<IngredientPlace>, IRecipeRepository
    {
        public static IRespositoryDefault<Recipe> Create()
        {
            throw new NotImplementedException();
        }

        public void InsertOrUpdate(Recipe entity)
        {
            throw new NotImplementedException();
        }
    }
}
