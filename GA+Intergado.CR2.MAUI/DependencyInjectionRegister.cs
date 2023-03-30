using GA_Intergado.CR2.IntegrationService.Settings;
using GA_Intergado.CR2.MAUI.Pages;
using GA_Intergado.CR2.MAUI.ViewModels;

namespace GA_Intergado.CR2.MAUI
{
    public static class DependencyInjectionRegister
    {
        public static IServiceCollection AddMauiServices(this IServiceCollection services)
        {
            services.AddTransient<LoginPage>();
            services.AddTransient<HomePage>();
            services.AddTransient<LoadingPage>();
            services.AddTransient<ServerIntegrationPage>();
            services.AddTransient<SettingsPage>();
            services.AddTransient<ServerIntegrationViewModel>();
            services.AddTransient<LoginViewModel>();
            services.AddTransient<SettingsViewModel>();
            return services;
        }
    }
}
