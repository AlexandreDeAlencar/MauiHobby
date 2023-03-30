using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GA_Intergado.CR2.App.Login.Command;
using MediatR;
using Microsoft.Extensions.Logging;

namespace GA_Intergado.CR2.MAUI.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {
        private IMediator _mediator;
        private ILogger _logger;

        public LoginViewModel(
            IMediator mediator
            , ILogger<LoginViewModel> logger
            )
        {
            _logger = logger;
            _mediator = mediator;
        }

        [ObservableProperty]
        private string userName;

        [ObservableProperty]
        private string password;

        [RelayCommand]
        public async Task Login()
        {
            var loginResult = await _mediator.Send(new LoginCommand(userName, password));

            if (!loginResult.IsError)
            {
                _logger.LogError($"Login failed: {loginResult.Errors.FirstOrDefault().Description}");
                await SecureStorage.SetAsync("hasAuth", "true");
                await Shell.Current.GoToAsync("///home");
            }
            else
            {
                _logger.LogInformation($"{userName} login sucessfull");
                await App.Current.MainPage.DisplayAlert("Login falhou", loginResult.Errors.FirstOrDefault().Description, "Tente Novamente");
            }
        }
    }
}
