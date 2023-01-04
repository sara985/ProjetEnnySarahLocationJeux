using ProjetEnnySarahLocationJeux.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetEnnySarahLocationJeux.Viewmodels
{
    public class MyGamesViewModel : ViewModelBase
    {
        List<VideoGame> _rentedGames;
        List<VideoGame> _bookedGames;
        List<VideoGame> _ownedGames;

        public MyGamesViewModel()
        {
            RentedGames = new List<VideoGame>();
            _bookedGames = new List<VideoGame>();
            RentedGames.Add(new VideoGame(1,200,"wii",5,"wii",new List<Copy>()));
        }

        public List<VideoGame> RentedGames { get => _rentedGames;
            set
            {
                _rentedGames = value;
                OnPropertyChanged("RentedGames");
            }
        }
    }
}
