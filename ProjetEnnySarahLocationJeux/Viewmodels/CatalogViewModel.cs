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
    public class CatalogViewModel : ViewModelBase
    {
        private List<VideoGame> _videoGames;
        private List<ConsoleAndVersion> _consoles;
        private ConsoleAndVersion _selectedConsole;
        private List<ConsoleAndVersion> _versions;
        private ConsoleAndVersion _selectedVersion;

        public List<VideoGame> VideoGames
        {
            get => _videoGames;
            set
            {
                _videoGames = value;
                OnPropertyChanged(nameof(VideoGames));
            }
        }

        public List<ConsoleAndVersion> Consoles
        {
            get => _consoles;
            set
            {
                _consoles = value;
                OnPropertyChanged(nameof(Consoles));
            }
        }

        public List<ConsoleAndVersion> Versions
        {
            get => _versions;
            set
            {
                _versions = value;
                OnPropertyChanged(nameof(Versions));                              
            }
        }

        public ConsoleAndVersion SelectedConsole
        {
            get => _selectedConsole;
            set
            {
                _selectedConsole = value;
                OnPropertyChanged(nameof(SelectedConsole));
                Versions = ConsoleAndVersion.GetVersionsByConsole(SelectedConsole.IdConsole);
            }
        }
        public ConsoleAndVersion SelectedVersion { get => _selectedVersion;
            set
            {
                _selectedVersion = value;
                OnPropertyChanged(nameof(SelectedVersion));
                if(SelectedVersion!=null)
                VideoGames = VideoGame.GetGamesByConsoleVersion(SelectedVersion.VersionId);
            }
        }

        public ICommand RentGameCommand { get; set; }
        public ICommand ResetGamesCommand { get; set; }


        public CatalogViewModel()
        {       
            VideoGames = VideoGame.GetAll();
            Consoles = ConsoleAndVersion.GetAllConsoles();
            ResetGamesCommand = new ViewModelCommand(ExecuteResetGames);
        }

        private void ExecuteResetGames(object obj)
        {
            VideoGames = VideoGame.GetAll();
        }
    }
}
