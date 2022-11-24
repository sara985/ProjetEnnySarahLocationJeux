using ProjetEnnySarahLocationJeux.DAO;
using ProjetEnnySarahLocationJeux.Interfaces;
using ProjetEnnySarahLocationJeux.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ProjetEnnySarahLocationJeux.Viewmodels
{
    internal class SignUpViewModel : ViewModelBase
    {
        private Player _player;
        private string _errorMessage;
        private bool _isViewVisible;

        public string ErrorMessage { get => _errorMessage; set { _errorMessage = value; OnPropertyChanged("ErrorMessage"); } }
        public bool IsViewVisible { get => _isViewVisible; set { _isViewVisible = value; OnPropertyChanged("IsViewVisible"); } }
        public Player Player { get => _player; set { _player = value; OnPropertyChanged("Player"); } }
    
        public ICommand VerifyUsernameCommand { get; set; }
        public ICommand VerifyPasswordCommand { get; set; }
        public ICommand AddPlayerCommand { get; set; }

        public SignUpViewModel()
        {
            _player = new Player();
            VerifyUsernameCommand = new ViewModelCommand(p => VerifyUsername(""));
            AddPlayerCommand = new ViewModelCommand(AddPlayer);
        }

        private void AddPlayer(object obj)
        {
            //TODO add player to db and maybe redirect or do new command to redirect
            //normally no message box in viewModel
            Player.CalculateSHA256();
            if (Player.Insert())
            {
                MessageBox.Show("Your account was created succesfully. You can now login.");
                IsViewVisible = false;
            }
        }

        private bool VerifyUsername(object obj)
        {
            bool isAvailable;
            if (true) //TODO search username in DB and return true or false
            {
                return true;
            }
        }
    }
}
