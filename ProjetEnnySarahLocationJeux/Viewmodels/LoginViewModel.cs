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
        private string _username = "admin";
        private string _password = "condorcet";
        private string _errorMessage;
        private bool _isViewVisible = true;
        private bool _goToSignup = false;
        //private bool _isAdmin = false;
        private bool _isLoginasAdmin = false;

        private PlayerDAO playerDAO;
        private AdminDao adminDAO;

        //properties
        public string Username { get => _username; set { _username = value; OnPropertyChanged("Username"); } }
        public string Password { get => _password; set { _password = value; OnPropertyChanged(nameof(Password)); } }
        public string ErrorMessage { get => _errorMessage; set { _errorMessage = value; OnPropertyChanged("ErrorMessage"); } }
        public bool IsViewVisible { get => _isViewVisible; set { _isViewVisible = value; OnPropertyChanged(nameof(IsViewVisible)); }}
        public bool IsLoginasAdmin { get => _isLoginasAdmin; set { _isLoginasAdmin = value; OnPropertyChanged(nameof(IsLoginasAdmin)); }}
        public bool GoToSignup { get => _goToSignup; set { _goToSignup = value; OnPropertyChanged("GoToSignup"); } }
        
        //public bool IsAdmin { get => _isAdmin; set { _isAdmin = value; OnPropertyChanged(nameof(IsAdmin)); } }

        // -> Commands
        public ICommand LoginCommand { get; set; }
        public ICommand ShowPasswordCommand { get; set; }
        public ICommand RememberPasswordCommand { get; set; }
        public ICommand RecoverPasswordCommand { get; set; }
        public ICommand GoToSignupCommand { get; set; }
        

        public LoginViewModel()
        {
            adminDAO = new AdminDao();
            playerDAO = new PlayerDAO();
            //these methods are delegated to the command
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
            Administrator a = new Administrator(Username,Password);
            a = adminDAO.isAdmin(a.Username, a.Password);
            if (a != null)
            {
                IsLoginasAdmin = true;
                Thread.CurrentPrincipal = new GenericPrincipal(
                    new GenericIdentity(Username), null);
                //Create an App property to hold the Id value throughout the whole application
                App.Current.Properties["UserId"] = a.Id;
                IsViewVisible = false;
            }
            else { 

                    Player p = new Player(Username,Password);
                    p = playerDAO.IsPlayer(p.Username, p.Password);
                    if (p!=null)
                    {
                        Thread.CurrentPrincipal = new GenericPrincipal(
                        new GenericIdentity(Username), null);
                        //Create an App property to hold the Id value throughout the whole application
                        App.Current.Properties["UserId"] = p.Id;
                        IsViewVisible = false;
                    }
                    else
                    {
                        ErrorMessage = "Invalid User";
                    }
                }
        }
        private bool CanExecuteLoginCommand(object obj)
        {
            bool validData;
            if (string.IsNullOrWhiteSpace(_username) || Username.Length < 2 ||
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
