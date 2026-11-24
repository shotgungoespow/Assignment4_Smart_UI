using Assignment4_Smart_UI.Models;
using Assignment4_Smart_UI.Services;
using Microsoft.Extensions.Hosting;
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
            string check = email;
            string second_check = password;
            EmailError = "";
            PasswordError = "";

            if (string.IsNullOrWhiteSpace(Email))
            {
                EmailError = "Please enter an email";
            }

            if (string.IsNullOrWhiteSpace(Password))
            {
                PasswordError = "Please enter a password";
                return;
            }

            int status = await DataRepository.CheckUserAuth(email, password);
            if(status == 0) { }
            else if (status == 1)
            {
                PasswordError = "Incorrect Password";
                return;
            }
            else if (status == 2)
            {
                EmailError = "Incorrect Email";
                return;
            }
            else
            {
                EmailError = "Incorrect Email";
                PasswordError = "Incorrect Password";
            }

            await Shell.Current.GoToAsync("//First_Page");
        }


        // Sign up logic
        private async Task SignUp()
        {
            EmailError = "";
            PasswordError = "";
            await Shell.Current.GoToAsync("//Register_Page");
        }

        #endregion


    }
}
