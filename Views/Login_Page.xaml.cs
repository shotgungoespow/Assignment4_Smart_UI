using Assignment4_Smart_UI.Services;
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

		EmailError.Text = "";
		PasswordError.Text = "";

		if (email == null || email == "")
		{
			EmailError.Text = "please enter an email";
		}
		if (password == null || password == "")
		{
			PasswordError.Text = "please enter a password";
		}

		foreach (User user in DataRepository.users)
		{
			bool Email_Check = false;
			bool Password_Check = false;
			if (user.Email == email)
			{
				Email_Check = true;
			}

			else if (EmailError.Text == "")
			{ EmailError.Text = "Incorrect email address"; }

			if (user.Password == password)
			{
				Password_Check = true;
			}

			else if (PasswordError.Text == "")
			{ PasswordError.Text = "Incorrect password"; }

			if (Email_Check && Password_Check)
			{
				EmailError.Text = "";
				PasswordError.Text = "Login Success";
				PasswordError.TextColor = Colors.Green;
				await Task.Delay(1000);
				await Shell.Current.GoToAsync("//First_Page");
			}
		}
	}
       
	public async void OnSignUpTapped(object sender, EventArgs e)
	{
        EmailError.Text = "";
        PasswordError.Text = "Moving to Register Page";
        PasswordError.TextColor = Colors.Green;
        await Task.Delay(1000);
        await Shell.Current.GoToAsync("//Register_Page");
    }
}