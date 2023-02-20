using GA_Intergado.CR2.App;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace GA_Intergado.CR2.MAUI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(MainPage).Assembly));
            builder.Services
                .AddApplication()
                .AddIntegrationApi2();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}