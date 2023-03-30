using GA_Intergado.CR2.MAUI.ViewModels;

namespace GA_Intergado.CR2.MAUI.Pages;

public partial class LoginPage : ContentPage
{
	public LoginPage(LoginViewModel loginViewModel)
	{
		InitializeComponent();
        this.BindingContext = loginViewModel;
	}
}