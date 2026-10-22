using Assignment4_Smart_UI.Models;

namespace Assignment4_Smart_UI.Views;

public partial class Login_Page : ContentPage
{
	public Login_Page()
	{
		InitializeComponent();
	}
    private async void OnLoginClicked(object sender, EventArgs e)
    {
		string email = EmailEntry.Text;
		string password = PasswordEntry.Text;

        if (email == "")
		{
			EmailError.Text = "please enter an email";
        }















    }
    public void OnForgotPasswordClicked(object sender, EventArgs e)
	{

	}
	public void OnSignUpTapped(object sender, EventArgs e)
	{

	}
}