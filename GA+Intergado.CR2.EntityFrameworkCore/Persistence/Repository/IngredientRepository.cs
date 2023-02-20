using GA_Intergado.CR2.Domain.Persistence.Base;
using GA_Intergado.CR2.Domain.IngredientPlaces;
using GA_Intergado.CR2.Domain.Ingredients;
using GA_Intergado.CR2.EntityFrameworkCore.Persistence.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA_Intergado.CR2.EntityFrameworkCore.Persistence.Repository
{
    public class IngredientRepository : RespositoryDefault<IngredientPlace>, IIngredientRepository
    {
        public static IRespositoryDefault<Ingredient> Create()
        {
            throw new NotImplementedException();
        }

        public void InsertOrUpdate(Ingredient entity)
        {
            throw new NotImplementedException();
        }
    }
}
