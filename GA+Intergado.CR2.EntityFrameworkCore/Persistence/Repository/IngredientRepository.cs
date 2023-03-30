using GA_Intergado.CR2.Domain.IngredientPlaces;
using GA_Intergado.CR2.Domain.Ingredients;
using GA_Intergado.CR2.EntityFrameworkCore.Persistence.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GA_Intergado.CR2.Domain.Common.Persistence.Base;

namespace GA_Intergado.CR2.EntityFrameworkCore.Persistence.Repository
{
    public class IngredientRepository : RespositoryDefault<Ingredient>, IIngredientRepository
    {
        public IngredientRepository(MyDbContext context) : base(context)
        {
        }
    }
}
