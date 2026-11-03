

namespace Assignment4_Smart_UI.Views;

public partial class Register_Page : ContentPage
{
	public Register_Page()
	{
		InitializeComponent();
	}
	public void OnRegisterClicked(object sender, EventArgs e)
	{
		string email = EmailEntry.Text;
		string password = PasswordEntry.Text;
		string confirm_password = ConfirmPasswordEntry.Text;

        if (email == null || email == "")
        {
            EmailError.Text = "please enter an email";
        }
        if (password == null || password == "")
        {
            PasswordError.Text = "please enter a password";
        }
        
        if (password != confirm_password)
        {
            PasswordError.Text = "passwords do not match";
        }

    }
	public async void OnLoginTapped(object sender, EventArgs e)
	{
        await Task.Delay(1000);
        await Shell.Current.GoToAsync("//Login_Page");
    }
}