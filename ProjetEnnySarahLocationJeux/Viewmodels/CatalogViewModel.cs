using ProjetEnnySarahLocationJeux.DAO;
using ProjetEnnySarahLocationJeux.POCO;
using ProjetEnnySarahLocationJeux.SmallWindows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ProjetEnnySarahLocationJeux.Viewmodels
{
    public class CatalogViewModel : ViewModelBase
    {
        private List<VideoGame> _allVideoGames;
        private List<VideoGame> _filteredList;
        private VideoGame _selectedVideoGame;
        private List<ConsoleAndVersion> _consoles;
        private ConsoleAndVersion _selectedConsole;
        private List<ConsoleAndVersion> _versions;
        private ConsoleAndVersion _selectedVersion;

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
                //todo: uncomment -> add comment just to make progrdamme work
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
                    SelectedVideoGame = FilteredList.FirstOrDefault();
                    //AllVideoGames = AllVideoGames.Where(x => x.Name.Equals(console)).ToList();
                }
            }
                    
        }
        public List<VideoGame> FilteredList
        {
            get => _filteredList;
            set
            {
                _filteredList = value;
                OnPropertyChanged("FilteredList");
            }
        }

        public VideoGame SelectedVideoGame
        {
            get => _selectedVideoGame;
            set
            {
                _selectedVideoGame = value;
                OnPropertyChanged(nameof(SelectedVideoGame));
            }
        }

        public ICommand RentGameCommand { get; set; }
        public ICommand BookGameCommand { get; set; }
        public ICommand ResetGamesCommand { get; set; }
        public ICommand OwnTheGameCommand { get; set; }
        

        public CatalogViewModel()
        {       
            AllVideoGames = VideoGame.GetAll();
            FilteredList = AllVideoGames;
            Consoles = ConsoleAndVersion.GetAllConsoles();
            ResetGamesCommand = new ViewModelCommand(ExecuteResetGames);
            OwnTheGameCommand = new ViewModelCommand(ExecuteOwnThisGame);
            RentGameCommand = new ViewModelCommand(ExecuteRentThisGame, CanExecuteRentThisGame);
            BookGameCommand = new ViewModelCommand(ExecuteBookThisGame, CanExecuteRentThisGame);
        }

        private void ExecuteBookThisGame(object obj)
        {
            Window window = new BookGameWindow(SelectedVideoGame);
            window.Show();
        }

        private bool CanExecuteRentThisGame(object obj)
        {
            if(SelectedVideoGame!=null && SelectedVideoGame.Copies.Count ==0 ) return false;
            return true;
        }

        private void ExecuteRentThisGame(object obj)
        {
            Window window = new RentGameWindow(SelectedVideoGame);
            window.Show();            
            //refresh sel videogame
            //MessageBox.Show("work");
            SelectedVideoGame = new VideoGameDAO().GetById(SelectedVideoGame.Id);
        }

        private void ExecuteOwnThisGame(object obj)
        {
            MessageBox.Show(obj.ToString());
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
