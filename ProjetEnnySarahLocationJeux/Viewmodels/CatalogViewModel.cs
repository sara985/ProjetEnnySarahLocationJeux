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
        private bool isTest;

        public List<VideoGame> AllVideoGames { 
            get => _allVideoGames;
            set
            {
                _allVideoGames = value;
                OnPropertyChanged("AllVideoGames");
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
                if (SelectedVersion != null)
                {
                    string console = getComboBoxesConsoleName();
                    FilteredList = AllVideoGames.Where(x => x.ConsoleAndVersion.Equals(console)).ToList();
                    //AllVideoGames = AllVideoGames.Where(x => x.Name.Equals(console)).ToList();
                }
            }
                    
        }

        public ICommand RentGameCommand { get; set; }
        public ICommand ResetGamesCommand { get; set; }
        public List<VideoGame> FilteredList { 
            get => _filteredList; 
            set
            {
                _filteredList = value;
                OnPropertyChanged("FilteredList");
            }
        }

        public bool IsTest { get => isTest; set => isTest = value; }

        public CatalogViewModel()
        {       
            AllVideoGames = VideoGame.GetAll();
            FilteredList = AllVideoGames;
            Consoles = ConsoleAndVersion.GetAllConsoles();
            ResetGamesCommand = new ViewModelCommand(ExecuteResetGames, CanExecuteResetGames);
        }

        private bool CanExecuteResetGames(object obj)
        {
            return false;
        }

        private void ExecuteResetGames(object obj)
        {
            FilteredList = AllVideoGames;
        }

        private string getComboBoxesConsoleName()
        {
            return SelectedConsole.Console + " " + SelectedVersion.Version;
        }
    }
}
