using ProjetEnnySarahLocationJeux.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ProjetEnnySarahLocationJeux.Viewmodels
{
    internal class MyAccountViewModel : ViewModelBase
    {
        private Player _player;
        private int nbrGameRented;
        private int nbrGameImRtg;
        bool isReadOnly;
        private string _errorMessage;
        private int _recupIdPlayer;
       

        public ICommand ModifyEmailCommand { get; set; }
        public ICommand ModifyUserNameCommand { get; set; }
        public ICommand ModifyPasswordCommand { get; set; }
        public ICommand DeletePlayerCommand { get; set; }
       

        public Player Player { get => _player; set { _player = value; OnPropertyChanged("Player");}}
        public int NbrGameRented { get => nbrGameRented; set { nbrGameRented = value; OnPropertyChanged(nameof(NbrGameRented)); } }
        public int NbrGameImRtg { get => nbrGameImRtg; set { nbrGameImRtg = value; OnPropertyChanged(nameof(NbrGameImRtg)); } }
        public bool IsReadOnly { get => isReadOnly; set => isReadOnly = value; }
        public string ErrorMessage { get => _errorMessage; set { _errorMessage = value; OnPropertyChanged(nameof(ErrorMessage)); } }

        public int RecupIdPlayer { get => _recupIdPlayer; set => _recupIdPlayer = value; }

        public MyAccountViewModel(){
            Player = Player.GetPlayerById(Int32.Parse(App.Current.Properties["UserId"].ToString()));
            nbrGameRented = Player.NbrGamesRented();
            nbrGameImRtg = Player.NbrGamesImRtng();
            IsReadOnly = true;
            ModifyEmailCommand = new ViewModelCommand(EditEmail);
            ModifyUserNameCommand = new ViewModelCommand(EditUsername);
            ModifyPasswordCommand = new ViewModelCommand(EditPassword);
            DeletePlayerCommand = new ViewModelCommand(DeletePlayer);
            RecupIdPlayer = Player.Id;
        }

        private void EditPassword(object obj)
        {
            Player.CalculateSHA256();
            if (Player.IsPasswordUpdated())
            {
                MessageBox.Show("Password Modified");
            }
        }

        private void DeletePlayer(object obj)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure? ", "Confirmation", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                if (Player.DeletePlayer())
                {

                    Player.DeleteCopy(RecupIdPlayer) ; 
                    MessageBox.Show("Your account is deleted. You will no longer be able to log in with this account.");
                }
                else
                {
                    MessageBox.Show("Your account was not deleted. You may be borrowing a game or have a game borrowed.");
                    //ErrorMessage = "Your account was not deleted. You may be borrowing a game or have a borrowed game.";
                }
            }
        }


        private void EditEmail(object obj)
        {
            if (Player.IsEmailUpdated())
            {
                MessageBox.Show("Email Modified");
            }
        }

        private void EditUsername(object obj)
        {
            if (Player.IsUserNameUpdated())
            {
                Thread.CurrentPrincipal = new GenericPrincipal(
                        new GenericIdentity(Player.Username), null);
                MessageBox.Show("Username Modified");
            }
        }
    }
}
