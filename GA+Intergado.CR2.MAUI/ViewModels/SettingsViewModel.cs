using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LocalizationResourceManager.Maui;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace GA_Intergado.CR2.MAUI.ViewModels
{
    public partial class SettingsViewModel : ObservableObject
    {
        private ILocalizationResourceManager _localizationResourceManager;
        private IConfiguration _configuration;
        private ILogger _logger;

        public SettingsViewModel(IConfiguration configuration
            ,ILocalizationResourceManager localizationResourceManager
            , ILogger<SettingsViewModel> logger)
        {
            _logger = logger;
            _configuration = configuration;
            _localizationResourceManager = localizationResourceManager;
            isPortuguese = _localizationResourceManager.CurrentCulture.TwoLetterISOLanguageName == "pt";
            language = isPortuguese ? "pt" : "en";
        }

        [ObservableProperty]
        string serverIntegrationAdress;

        [ObservableProperty]
        [NotifyPropertyChangedFor( nameof(Language) )]
        bool isPortuguese;

        [ObservableProperty]
        string language;

        partial void OnIsPortugueseChanged(bool value)
        {
            string lang = _localizationResourceManager.CurrentCulture.TwoLetterISOLanguageName;
            if (lang == "pt")
            {
                _localizationResourceManager.CurrentCulture = new System.Globalization.CultureInfo("en");
            }
            else if (lang == "en")
            {
                _localizationResourceManager.CurrentCulture = new System.Globalization.CultureInfo("pt");
            }
            language = value ? "pt" : "en";
        }


        [RelayCommand]
        public async void SaveConfiguration()
        {
            Preferences.Default.Set("IntegrationServiceHostAdress", ServerIntegrationAdress);

            _configuration["IntegrationServiceHostAdress:HostAdress"] = Preferences.Default.Get("IntegrationServiceHostAdress", _configuration["IntegrationServiceHostAdress:HostAdress"]);

            _logger.LogInformation($"IntegrationServiceHostAdress setted as: {ServerIntegrationAdress}");

            await App.Current.MainPage.DisplayAlert(_localizationResourceManager["SettingsHeader"], _localizationResourceManager["IntegrationServiceHostAdressSetted"], _localizationResourceManager["Confirm"]);
        }
    }
}
