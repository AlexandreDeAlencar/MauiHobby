using GA_Intergado.CR2.App.ServerIntegration.Services;
using GA_Intergado.CR2.IntegrationApi2;
using Microsoft.Extensions.DependencyInjection;

namespace GA_Intergado.CR2.App
{
    public static class DependencyInjectionRegister
    {
        public static IServiceCollection AddIntegrationApi2(this IServiceCollection services)
        {
            services.AddSingleton<IIntegrationService, IntegrationService>();
            return services;
        }
    }
}