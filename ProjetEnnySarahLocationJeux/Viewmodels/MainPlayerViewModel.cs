using ProjetEnnySarahLocationJeux.CustomControls;
using ProjetEnnySarahLocationJeux.Interfaces;
using ProjetEnnySarahLocationJeux.POCO;
using ProjetEnnySarahLocationJeux.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ProjetEnnySarahLocationJeux.Viewmodels
{
    internal class MainPlayerViewModel : ViewModelBase, ICloseWindows
    {
        private Player _currentPlayer;
        private NavButton _selectedButton;
        private Uri _frameSource;

        public Player CurrentPlayer { get { return _currentPlayer; }
        set { 
                _currentPlayer = value;
                OnPropertyChanged("CurrentPlayer");
            }
        }

        public MainPlayerViewModel()
        {
            LoadCurrentUserData();
            LogoutCommand = new ViewModelCommand(ExecuteLogout);
        }

        private void ExecuteLogout(object obj)
        {
            App.Current.Properties.Remove("UserId");
            MessageBox.Show("You have succesfully been disconnected. You will now be redirected to the login form.");
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            //ApplicationStart();
            Close?.Invoke();
        }

        private void LoadCurrentUserData()
        {
            Player p = Player.GetPlayerByUsername(Thread.CurrentPrincipal.Identity.Name);
            if (p != null)
            {
                _currentPlayer = p;
            }
        }

        public ICommand LogoutCommand { get; set; }
        public ICommand SelectionChangedCommand { get; set; }
        public NavButton SelectedButton
        {
            get => _selectedButton; set { { _selectedButton = value; 
                    OnPropertyChanged("SelectedButton");
                    FrameSource = SelectedButton.NavLink;
                } }
        }
        public Uri FrameSource
        {
            get => _frameSource;
            set { _frameSource = value; 
                OnPropertyChanged("FrameSource"); 
            }
        }

        public Action Close { get; set; }
    }
}
