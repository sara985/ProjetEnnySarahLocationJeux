using ProjetEnnySarahLocationJeux.DAO;
using ProjetEnnySarahLocationJeux.POCO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;

namespace ProjetEnnySarahLocationJeux.Viewmodels
{
    public class LoginViewModel : ViewModelBase
    {
        private string _username;
        private string _password;
        private string _errorMessage;
        private bool _isViewVisible = true;
        private bool _goToSignup = false;

        private PlayerDAO playerDAO;

        //properties
        public string Username { get => _username; set { _username = value; OnPropertyChanged("Username"); } }
        public string Password { get => _password; set { _password = value; OnPropertyChanged(nameof(Password)); } }
        public string ErrorMessage { get => _errorMessage; set { _errorMessage = value; OnPropertyChanged("ErrorMessage"); } }
        public bool IsViewVisible { get => _isViewVisible; set { _isViewVisible = value; 
                OnPropertyChanged(nameof(IsViewVisible)); } }

        // -> Commands
        public ICommand LoginCommand { get; set; }
        public ICommand ShowPasswordCommand { get; set; }
        public ICommand RememberPasswordCommand { get; set; }
        public ICommand RecoverPasswordCommand { get; set; }
        public ICommand GoToSignupCommand { get; set; }
        public bool GoToSignup { get => _goToSignup; set { _goToSignup = value; OnPropertyChanged("GoToSignup"); } }

        public LoginViewModel()
        {
            //these methods are delegated to the command
            playerDAO = new PlayerDAO();
            LoginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
            RecoverPasswordCommand = new ViewModelCommand(p => ExecuteRecoverPasswordCommand("", ""));
            GoToSignupCommand = new ViewModelCommand(ExecuteGoToSignupCommand);
        }

        private void ExecuteRecoverPasswordCommand(string username, string email)
        {
            throw new NotImplementedException();
        }

        private void ExecuteLoginCommand(object obj)
        {
            Player p = new Player(Username,Password);
            var isValidUser = playerDAO.IsUser(p.Username, p.Password);
            if (isValidUser)
            {
                Thread.CurrentPrincipal = new GenericPrincipal(
                    new GenericIdentity(Username), null);
                IsViewVisible = false;
            }
            else
            {
                ErrorMessage = "invalidUser";
            }
        }
        private bool CanExecuteLoginCommand(object obj)
        {
            bool validData;
            if (string.IsNullOrWhiteSpace(_username) || Username.Length < 3 ||
                Password == null || Password.Length < 3)
                validData = false;
            else
                validData = true;
            return validData;
        }

        private void ExecuteGoToSignupCommand(object obj)
        {
            GoToSignup = true;
            IsViewVisible=false;
        }
    }
}
