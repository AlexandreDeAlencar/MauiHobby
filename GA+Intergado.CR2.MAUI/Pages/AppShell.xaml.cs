using GA_Intergado.CR2.MAUI.Pages;
using System.Diagnostics;

namespace GA_Intergado.CR2.MAUI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("login", typeof(LoginPage));
            Routing.RegisterRoute("home", typeof(HomePage));
            Routing.RegisterRoute("serverIntegration", typeof(ServerIntegrationPage));
            Routing.RegisterRoute("settings", typeof(SettingsPage));
        }
    }
}