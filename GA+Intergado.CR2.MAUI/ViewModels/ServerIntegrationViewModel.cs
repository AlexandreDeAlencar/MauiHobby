using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GA_Intergado.CR2.App.ServerIntegration.Commands;
using GA_Intergado.CR2.App.ServerIntegration.DTOs;
using GA_Intergado.CR2.Domain.Users;
using GA_Intergado.CR2.IntegrationService.Model;
using LocalizationResourceManager.Maui;
using MediatR;
using Microsoft.Extensions.Logging;

namespace GA_Intergado.CR2.MAUI.ViewModels
{
    public partial class ServerIntegrationViewModel : ObservableObject
    {
        private IMediator _mediator;
        private ILocalizationResourceManager _localizationResourceManager;
        private ILogger _logger;


        public ServerIntegrationViewModel(IMediator mediator
           , ILocalizationResourceManager localizationResourceManager
            , ILogger<ServerIntegrationViewModel> logger)
        {
            this._logger = logger;
            this._localizationResourceManager = localizationResourceManager;
            this._mediator = mediator;
        }

        [RelayCommand]
        public async Task DownloadEntites()
        {

            List<ServerIntegrationItemDTO> ListaParaDownload = new List<ServerIntegrationItemDTO>
            {
                new ServerIntegrationItemDTO(typeof(UserAPIVM),typeof(User), "Users","view_usuarios")
                //new ServerIntegrationItemDTO(typeof(ReceitaCR1VM), typeof(Recipe),"Recipes","view_receitas")
            };

            var DownloadEntitesResult = await _mediator.Send(new DownloadEtitiesCommand(ListaParaDownload));
            
            if (DownloadEntitesResult.IsError)
            {
                _logger.LogError($"Server integration failed {DownloadEntitesResult.Errors.FirstOrDefault().Description}");
                await App.Current.MainPage.DisplayAlert(_localizationResourceManager["FailedIntegration"], DownloadEntitesResult.Errors.FirstOrDefault().Description, _localizationResourceManager["TryItAgain"]);
            }
            else
            {
                _logger.LogInformation($"Server integration sccess");
                await App.Current.MainPage.DisplayAlert(_localizationResourceManager["SuccessfulIntegration"], _localizationResourceManager["UsersIntegrated"], _localizationResourceManager["Confirm"]);
            }

            return;
        }
    }
}
