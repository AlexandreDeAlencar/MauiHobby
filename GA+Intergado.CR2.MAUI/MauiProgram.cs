using GA_Intergado.CR2.App;
using GA_Intergado.CR2.EntityFrameworkCore;
using GA_Intergado.CR2.EntityFrameworkCore.Persistence;
using GA_Intergado.CR2.IntegrationService;
using GA_Intergado.CR2.MAUI.Resources.Languages.Common;
using GA_Intergado.CR2.MAUI.Resources.Languages.Home;
using GA_Intergado.CR2.MAUI.Resources.Languages.Loading;
using GA_Intergado.CR2.MAUI.Resources.Languages.Login;
using GA_Intergado.CR2.MAUI.Resources.Languages.ServerIntegration;
using GA_Intergado.CR2.MAUI.Resources.Languages.Settings;
using LocalizationResourceManager.Maui;
using MetroLog.MicrosoftExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace GA_Intergado.CR2.MAUI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseLocalizationResourceManager(settings =>
                {
                    settings.AddResource(LoginResources.ResourceManager);
                    settings.AddResource(ServerIntegrationResources.ResourceManager);
                    settings.AddResource(SettingsResources.ResourceManager);
                    settings.AddResource(HomeResources.ResourceManager);
                    settings.AddResource(LoadingResources.ResourceManager);
                    settings.AddResource(CommonResources.ResourceManager);
                    settings.RestoreLatestCulture(true);
                }
                )
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            var assembly = Assembly.GetExecutingAssembly();
            var settingsFilePath = assembly.GetManifestResourceNames()
                .Where(r => r.Contains("appsettings.json"))
                .FirstOrDefault();
            var stream = assembly.GetManifestResourceStream(settingsFilePath);

            var config = new ConfigurationBuilder()
                        .AddJsonStream(stream)
                        .Build();

            builder.Configuration.AddConfiguration(config);

            builder.Services.AddDbContext<MyDbContext>(
                options => options.UseSqlite($"Filename={GetDatabasePath()}", x => x.MigrationsAssembly(nameof(EntityFrameworkCore))));
            
            builder.Services
                .AddApplication()
                .AddEntityFramework()
                .AddIntegrationServices(builder.Configuration)
                .AddMauiServices();

            string lang = Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName;
            if(lang == "pt")
            {
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("pt");
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("pt");
            }

            builder.Logging.AddStreamingFileLogger(
                options =>
                {
                    options.MinLevel = LogLevel.Debug;
                    options.RetainDays = 20;
                    options.FolderPath = Path.Combine(
                        FileSystem.CacheDirectory,
                        "MetroLogs");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif
            return builder.Build();
        }

        public static string GetDatabasePath()
        {
            var databasePath = "";
            var databaseName = "Maui.db3";

            //if (DeviceInfo.Platform == DevicePlatform.WinUI)
            //{
            //    databasePath = "Data Source=C:\\sqlite\\cr2database.db";
            //}
            if (DeviceInfo.Platform == DevicePlatform.Android)
            {
                databasePath = Path.Combine(FileSystem.AppDataDirectory, databaseName);
            }
            if (DeviceInfo.Platform == DevicePlatform.iOS)
            {
                SQLitePCL.Batteries_V2.Init();
                databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "..", "Library", databaseName); ;
            }

            return databasePath;
        }
    }
}