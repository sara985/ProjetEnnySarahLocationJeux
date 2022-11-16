using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;

namespace ProjetEnnySarahLocationJeux.Viewmodels
{
    //TODO continue 19min30
    public class LoginViewModel : ViewModelBase
    {
        private string _username;
        private string _password;
        private string _errorMessage;

        //properties
        public string Username { get => _username; set { _username = value; OnPropertyChanged("Username"); } }
        public string Password { get => _password; set { _password = value; OnPropertyChanged(nameof(Password)); } }
        public string ErrorMessage { get => _errorMessage; set { _errorMessage = value; OnPropertyChanged("ErrorMessage"); } }
    
        // -> Commands
        public ICommand LoginCommand { get; set; }
        public ICommand ShowPasswordCommand { get; set; }
        public ICommand RememberPasswordCommand { get; set; }

        public LoginViewModel()
        {
            //these methods are delegated to the command
            LoginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
            LoginCommand = new ViewModelCommand(p => ExecuteRecoverPasswordCommand("",""));
        }

        private void ExecuteRecoverPasswordCommand(string username, string email)
        {
            throw new NotImplementedException();
        }

        private void ExecuteLoginCommand(object obj)
        {
            throw new NotImplementedException();
        }

        private bool CanExecuteLoginCommand(object obj)
        {
            bool validData;
            if (string.IsNullOrWhiteSpace(Username) || Username.Length < 3 ||
                Password == null || Password.Length < 3)
                validData = false;
            else
                validData = true;
            return validData;
        }
    }
}
