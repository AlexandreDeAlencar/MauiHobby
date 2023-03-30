using GA_Intergado.CR2.App.ServerIntegration.Commands;
using GA_Intergado.CR2.App.ServerIntegration.DTOs;
using GA_Intergado.CR2.Domain.Recipes;
using MediatR;
using GA_Intergado.CR2.Domain.Users;
using ServiceLocation;
using GA_Intergado.CR2.MAUI.ViewModels;
using Microsoft.Extensions.Configuration;

namespace GA_Intergado.CR2.MAUI.Pages
{
    public partial class ServerIntegrationPage : ContentPage

    {
        public ServerIntegrationPage(ServerIntegrationViewModel vm, IConfiguration configuration)
        {
            InitializeComponent();
            BindingContext = vm;
            configuration["IntegrationServiceHostAdress:HostAdress"] = Preferences.Default.Get("IntegrationServiceHostAdress", configuration["IntegrationServiceHostAdress:HostAdress"]); ;
        }
    }
}