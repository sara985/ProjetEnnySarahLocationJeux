using ProjetEnnySarahLocationJeux.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjetEnnySarahLocationJeux.Viewmodels
{
    internal class MainPlayerViewModel : ViewModelBase
    {
        private Player _currentPlayer;

        public Player CurrentPlayer { get { return _currentPlayer; }
        set { 
                _currentPlayer = value;
                OnPropertyChanged("CurrentPlayer");
            }
        }

        public MainPlayerViewModel()
        {
            LoadCurrentUserData();
        }

        private void LoadCurrentUserData()
        {
            Player p = Player.GetPlayerByUsername(Thread.CurrentPrincipal.Identity.Name);
            if (p != null)
            {
                _currentPlayer = p;
            }
        }
    }
}
