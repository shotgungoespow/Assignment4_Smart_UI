namespace Assignment4_Smart_UI.Views;

public partial class Register_Page : ContentPage
{
	public Register_Page()
	{
		InitializeComponent();
	}
	public void OnRegisterClicked(object sender, EventArgs e)
	{

	}
	public async void OnLoginTapped(object sender, EventArgs e)
	{
        await Task.Delay(1000);
        await Shell.Current.GoToAsync("//Login_Page");
    }
}