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
        private int nbrGameRented;
        private int nbrGameImRtg;
       

        public Player Player { 
            get => _player;
            set { 
                _player = value;
                OnPropertyChanged("Player");
            }
        }
        
        public int NbrGameRented { get => nbrGameRented; set { nbrGameRented = value; OnPropertyChanged(nameof(NbrGameRented)); } }

        public int NbrGameImRtg { get => nbrGameImRtg; set { nbrGameImRtg = value; OnPropertyChanged(nameof(NbrGameImRtg)); } }

        public MyAccountViewModel(){
            Player = Player.GetPlayerById(Int32.Parse(App.Current.Properties["UserId"].ToString()));
            nbrGameRented = Player.NbrGamesRented();
            nbrGameImRtg = Player.NbrGamesImRtng();
            
        }
    }
}
