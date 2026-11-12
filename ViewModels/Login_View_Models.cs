using Assignment4_Smart_UI.Models;
using Assignment4_Smart_UI.Services;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Assignment4_Smart_UI.ViewModels
{
    internal class Login_View_Models : Base_View_Model
    {
        #region PROPERTIES
        // Email property
        private string email;
        public string Email
        {
            get => email;
            set
            {
                if (email != value)
                {
                    email = value;
                    OnPropertyChanged();
                }
            }
        }


        // Password property
        private string password;
        public string Password
        {
            get => password;
            set
            {
                if (password != value)
                {
                    password = value;
                    OnPropertyChanged();
                }
            }
        }


        // Email error property
        private string emailError;
        public string EmailError
        {
            get => emailError;
            set
            {
                if (emailError != value)
                {
                    emailError = value;
                    OnPropertyChanged();
                }
            }
        }


        // Password error property
        private string passwordError;
        public string PasswordError
        {
            get => passwordError;
            set
            {
                if (passwordError != value)
                {
                    passwordError = value;
                    OnPropertyChanged();
                }
            }
        }

        private string msgColor;
        public string MsgColor
        {
            get => msgColor;
            set
            {
                if (msgColor != value)
                {
                    msgColor = value;
                    OnPropertyChanged();
                }
            }
        }

        #endregion


        #region commands
        // Commands
        public ICommand LoginCommand { get; }
        public ICommand SignUpCommand { get; }


        #endregion

        // Constructor
        public Login_View_Models()
        {
            LoginCommand = new Command(async () => await Login());
            SignUpCommand = new Command(async () => await SignUp());
        }


        #region methods

        // Login logic
        private async Task Login()
        {
            EmailError = "";
            PasswordError = "";
            bool loginValid = true;

            if (string.IsNullOrWhiteSpace(Email))
            {
                EmailError = "Please enter an email";
                loginValid  = false;
            }

            if (string.IsNullOrWhiteSpace(Password))
            {
                PasswordError = "Please enter a password";
                loginValid= false;
            }

            User? matchedUser = DataRepository.users.FirstOrDefault(user => (user.Email).ToLower() == Email.ToLower());
            
            if (matchedUser == null)
            {
                EmailError = "Incorrect Email";
                loginValid = false;
            }
            else
            {
                if (matchedUser.Password != password)
                {
                    PasswordError = "Incorrect Password";
                    loginValid = false;
                }
            }

            if (loginValid)
            {
                
                passwordError = "Login Successful";
                await Task.Delay(1000);
                await Shell.Current.GoToAsync("//First_Page");
            }
        }


        // Sign up logic
        private async Task SignUp()
        {
            EmailError = "";
            PasswordError = "";

            

            await Task.Delay(1000);

            await Shell.Current.GoToAsync("//Register_Page");
        }

        #endregion


    }
}
