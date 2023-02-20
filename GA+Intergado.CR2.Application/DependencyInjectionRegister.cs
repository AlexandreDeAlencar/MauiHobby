using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace GA_Intergado.CR2.App
{
    public static class DependencyInjectionRegister
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DependencyInjectionRegister).Assembly));
            return services;
        }
    }
}