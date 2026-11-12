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
        // Event required for notifying the UI
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(
            [CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(propertyName));
        }


        // Email property
        private string email = "";

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
        private string password = "";

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
        private string emailError = "";

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
        private string passwordError = "";

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


        // Status message
        private string statusMessage = "";

        public string StatusMessage
        {
            get => statusMessage;
            set
            {
                if (statusMessage != value)
                {
                    statusMessage = value;
                    OnPropertyChanged();
                }
            }
        }


        // Status color
        private Color statusColor = Colors.Red;

        public Color StatusColor
        {
            get => statusColor;
            set
            {
                if (statusColor != value)
                {
                    statusColor = value;
                    OnPropertyChanged();
                }
            }
        }


        // Status visibility
        private bool isStatusVisible;

        public bool IsStatusVisible
        {
            get => isStatusVisible;
            set
            {
                if (isStatusVisible != value)
                {
                    isStatusVisible = value;
                    OnPropertyChanged();
                }
            }
        }


        // Commands
        public ICommand LoginCommand { get; }
        public ICommand SignUpCommand { get; }


        // Constructor
        public Login_View_Models()
        {
            LoginCommand = new Command(async () => await Login());
            SignUpCommand = new Command(async () => await SignUp());
        }


        // Login logic
        private async Task Login()
        {
            EmailError = "";
            PasswordError = "";
            StatusMessage = "";
            IsStatusVisible = false;

            if (string.IsNullOrWhiteSpace(Email))
            {
                EmailError = "Please enter an email";
            }

            if (string.IsNullOrWhiteSpace(Password))
            {
                PasswordError = "Please enter a password";
            }

            if (EmailError != "" || PasswordError != "")
            {
                return;
            }

            User? matchedUser = DataRepository.users.FirstOrDefault(
                user => user.Email == Email &&
                        user.Password == Password
            );

            if (matchedUser == null)
            {
                bool emailExists = DataRepository.users.Any(
                    user => user.Email == Email
                );

                if (!emailExists)
                {
                    EmailError = "Incorrect email address";
                }
                else
                {
                    PasswordError = "Incorrect password";
                }

                return;
            }

            StatusMessage = "Login Success";
            StatusColor = Colors.Green;
            IsStatusVisible = true;

            await Task.Delay(1000);

            await Shell.Current.GoToAsync("//First_Page");
        }


        // Sign up logic
        private async Task SignUp()
        {
            EmailError = "";
            PasswordError = "";

            StatusMessage = "Moving to Register Page";
            StatusColor = Colors.Green;
            IsStatusVisible = true;

            await Task.Delay(1000);

            await Shell.Current.GoToAsync("//Register_Page");
        }




    }
}
