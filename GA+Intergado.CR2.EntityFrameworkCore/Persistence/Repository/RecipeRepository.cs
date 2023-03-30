using GA_Intergado.CR2.Domain.Common.Persistence.Base;
using GA_Intergado.CR2.Domain.IngredientPlaces;
using GA_Intergado.CR2.Domain.Recipes;
using GA_Intergado.CR2.EntityFrameworkCore.Persistence.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA_Intergado.CR2.EntityFrameworkCore.Persistence.Repository
{
    public class RecipeRepository : RespositoryDefault<Recipe>, IRecipeRepository
    {
        public RecipeRepository(MyDbContext context) : base(context)
        {
        }
    }
}
