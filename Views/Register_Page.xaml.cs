
using Assignment4_Smart_UI.ViewModels;
using System.Text.RegularExpressions;
namespace Assignment4_Smart_UI.Views;

public partial class Register_Page : ContentPage
{
	public Register_Page()
	{
		InitializeComponent();
		//BindingContext = new Register_View_Models();
	}
	public async void OnRegisterClicked(object sender, EventArgs e)
	{
		string email = EmailEntry.Text;
		string password = PasswordEntry.Text;
		string confirm_password = ConfirmPasswordEntry.Text;
		Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
		Match match = regex.Match(email);


		EmailError.Text = "";
		PasswordError.Text = "";
		ConfirmPasswordError.Text = "";

		if (email == null || email == "")
		{
			EmailError.Text = "please enter an email";
		}

		if (!match.Success)
		{
			EmailError.Text = "incorrect email format";
		}

		if (password == null || password == "")
		{
			PasswordError.Text = "please enter a password";
		}
		else if (ConfirmPasswordEntry.Text == null || ConfirmPasswordEntry.Text == "")
		{
			ConfirmPasswordError.Text = "please confirm password";
		}
		else if (password != confirm_password)
		{
			ConfirmPasswordError.Text = "passwords do not match";
		}
		else
		{
			ConfirmPasswordError.TextColor = Colors.Green;
			ConfirmPasswordError.Text = "Register Succes";
			await Task.Delay(1000);
			await Shell.Current.GoToAsync("//First_Page");
		}

	}
	public async void OnLoginTapped(object sender, EventArgs e)
	{
		ConfirmPasswordError.Text = "";
		ConfirmPasswordError.TextColor = Colors.Green;
		ConfirmPasswordError.Text = "Moving to Login Page";
		await Task.Delay(1000);
		await Shell.Current.GoToAsync("//Login_Page");

	}
}