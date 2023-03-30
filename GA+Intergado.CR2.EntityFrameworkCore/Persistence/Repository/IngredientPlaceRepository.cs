using GA_Intergado.CR2.Domain.IngredientPlaces;
using GA_Intergado.CR2.EntityFrameworkCore.Persistence.Repository.Base;
using GA_Intergado.CR2.Domain.Common.Persistence.Base;
using GA_Intergado.CR2.Domain.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA_Intergado.CR2.EntityFrameworkCore.Persistence.Repository
{
    public class IngredientPlaceRepository : RespositoryDefault<IngredientPlace>, IIngredientPlaceRepository
    {
        public IngredientPlaceRepository(MyDbContext context) : base(context)
        {
        }
    }
}
