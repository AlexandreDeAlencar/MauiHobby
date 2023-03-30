using GA_Intergado.CR2.MAUI.ViewModels;

namespace GA_Intergado.CR2.MAUI.Pages;

public partial class SettingsPage : ContentPage
{
	public SettingsPage(SettingsViewModel vm)
	{
		InitializeComponent();
        this.BindingContext = vm;
    }
}