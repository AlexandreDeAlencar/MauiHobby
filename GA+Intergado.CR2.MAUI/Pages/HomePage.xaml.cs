namespace GA_Intergado.CR2.MAUI.Pages;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
	}
    private async void LogoutButton_Clicked(object sender, EventArgs e)
    {
        if (await DisplayAlert("Certeza que deseja sair?", "Voc� ser� deslogado", "Sim", "N�o"))
        {
            SecureStorage.RemoveAll();
            await Shell.Current.GoToAsync("///login");
        }
    }
}