using GA_Intergado.CR2.App.Common.UnitOfWork;
using GA_Intergado.CR2.Domain.Common.Models;
using GA_Intergado.CR2.Domain.IngredientPlaces;
using GA_Intergado.CR2.Domain.Ingredients;
using GA_Intergado.CR2.Domain.Common.Persistence.Base;
using GA_Intergado.CR2.Domain.Recipes;
using GA_Intergado.CR2.EntityFrameworkCore.Persistence;
using GA_Intergado.CR2.EntityFrameworkCore.Persistence.Repository;
using GA_Intergado.CR2.EntityFrameworkCore.Persistence.Repository.Base;
using GA_Intergado.CR2.EntityFrameworkCore.Persistence.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GA_Intergado.CR2.Domain.Users;

namespace GA_Intergado.CR2.EntityFrameworkCore
{
    public static class DependencyInjectionRegister
    {
        public static IServiceCollection AddEntityFramework(this IServiceCollection services)
        {
            services.AddSingleton<IUnitOfWork, UnitOfWork>();
            services.AddSingleton(typeof(IRepositoryDefault<>), typeof(RespositoryDefault<>));
            services.AddSingleton<IIngredientRepository, IngredientRepository>();
            services.AddSingleton<IIngredientPlaceRepository, IngredientPlaceRepository>();
            services.AddSingleton<IRecipeRepository, RecipeRepository>();
            services.AddSingleton<IUserRepository, UserRepository>();
            return services;
        }
    }
}
