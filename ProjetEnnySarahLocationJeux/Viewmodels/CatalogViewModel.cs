using ProjetEnnySarahLocationJeux.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetEnnySarahLocationJeux.Viewmodels
{
    public class CatalogViewModel : ViewModelBase
    {
        private List<VideoGame> _videoGames;

        internal List<VideoGame> VideoGames
        {
            get => _videoGames;
            set
            {
                _videoGames = value;
                OnPropertyChanged("VideoGames");
            }
        }

        public CatalogViewModel()
        {
            _videoGames = new List<VideoGame>();
            _videoGames.Add(new VideoGame(1, 2000, "Wii sports", 5, new ConsoleAndVersion()));
        }
    }
}
