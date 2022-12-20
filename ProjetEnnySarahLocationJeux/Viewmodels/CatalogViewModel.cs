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
        private List<VideoGame> _allVideoGames;
        private List<VideoGame> _filteredList;
        private List<ConsoleAndVersion> _consoles;
        private ConsoleAndVersion _selectedConsole;
        private List<ConsoleAndVersion> _versions;
        private ConsoleAndVersion _selectedVersion;

        public List<VideoGame> AllVideoGames { 
            get => _allVideoGames;
            set
            {
                _allVideoGames = value;
                OnPropertyChanged(nameof(AllVideoGames));
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
                //todo: uncomment -> add comment just to make progrdamme work
                Versions = ConsoleAndVersion.GetVersionsByConsole(SelectedConsole.IdConsole);
            }
        }
        public ConsoleAndVersion SelectedVersion { get => _selectedVersion;
            set
            {
                _selectedVersion = value;
                OnPropertyChanged(nameof(SelectedVersion));
                string console = getComboBoxesConsoleName();
                if (SelectedVersion != null)
                {
                    FilteredList = AllVideoGames.Where(x => x.ConsoleAndVersion.Equals(console)).ToList();
                    //AllVideoGames = AllVideoGames.Where(x => x.Name.Equals(console)).ToList();
                }
            }
                    
        }

        public ICommand RentGameCommand { get; set; }
        public ICommand ResetGamesCommand { get; set; }
        public List<VideoGame> FilteredList { get => _filteredList; 
            set
            {
                _filteredList = value;
                OnPropertyChanged("FilteredList");
            }
        } 

        public CatalogViewModel()
        {       
            AllVideoGames = VideoGame.GetAll();
            _filteredList = AllVideoGames;
            Consoles = ConsoleAndVersion.GetAllConsoles();
            ResetGamesCommand = new ViewModelCommand(ExecuteResetGames);
        }

        private void ExecuteResetGames(object obj)
        {
            _filteredList = AllVideoGames;
        }

        public string getComboBoxesConsoleName()
        {
            return SelectedConsole.Console + " " + SelectedVersion.Version;
        }
    }
}
