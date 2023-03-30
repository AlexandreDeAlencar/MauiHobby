using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GA_Intergado.CR2.App
{
    public static class DependencyInjectionRegister
    {
        public static IServiceCollection AddExternalDevices(this IServiceCollection services, IConfiguration configuration)
        {
            return services;
        }
    }
}