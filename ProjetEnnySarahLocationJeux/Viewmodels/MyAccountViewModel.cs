using ProjetEnnySarahLocationJeux.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProjetEnnySarahLocationJeux.Viewmodels
{
    internal class MyAccountViewModel : ViewModelBase
    {
        private Player _player;
       

        public Player Player { 
            get => _player;
            set { 
                _player = value;
                OnPropertyChanged("Player");
            }
        }

        public MyAccountViewModel(){
            Player = Player.GetPlayerById(Int32.Parse(App.Current.Properties["UserId"].ToString()));
        }
    }
}
