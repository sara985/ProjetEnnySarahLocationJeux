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

        public List<VideoGame> VideoGames
        {
            get => _videoGames;
            set
            {
                _videoGames = value;
                OnPropertyChanged(nameof(VideoGames));
            }
        }

        public CatalogViewModel()
        {
            VideoGames = new List<VideoGame>();
            VideoGames.Add(new VideoGame(1, 2000, "Wii sports", 5, new ConsoleAndVersion(1, "Nintendo", "Wii")));
            VideoGames.Add(new VideoGame(2, 2000, "Wii Boxe", 4, new ConsoleAndVersion(1, "Xbox", "One")));
            VideoGames.Add(new VideoGame(3, 2000, "Wii Derby", 3, new ConsoleAndVersion(1, "Xbox", "360")));
            VideoGames.Add(new VideoGame(3, 2000, "Wii Derby", 3, new ConsoleAndVersion(1, "Nintendo", "Wii")));
            VideoGames.Add(new VideoGame(3, 2000, "Wii Derby", 3, new ConsoleAndVersion(1, "Nintendo", "Wii")));
        }

    }
}
