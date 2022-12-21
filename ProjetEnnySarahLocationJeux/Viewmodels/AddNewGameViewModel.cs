using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ProjetEnnySarahLocationJeux.POCO;

namespace ProjetEnnySarahLocationJeux.Viewmodels
{
    internal class AddNewGameViewModel : ViewModelBase
    {
        private VideoGame _videoGame;
        private string _errorMessage;
        private List<ConsoleAndVersion> _consoles;
        private ConsoleAndVersion _selectedConsole;
        private List<ConsoleAndVersion> _versions;
        private ConsoleAndVersion _selectedVersion;



        public ICommand AddVideoGameCommand { get; set; }   
        public AddNewGameViewModel()
        {
            _videoGame = new VideoGame();
            AddVideoGameCommand = new ViewModelCommand(AddGame);
            Consoles = ConsoleAndVersion.GetAllConsoles();
        }

        private void AddGame(object obj)
        {
            string consoleVersion = getComboBoxesConsoleName();
            VideoGame.ConsoleAndVersion = consoleVersion;
            if (VideoGame.Insert())
            {
                MessageBox.Show("New game succesfully added");
            }
        }

        public VideoGame VideoGame { get => _videoGame; set => _videoGame = value; }
        public string ErrorMessage { get => _errorMessage; set => _errorMessage = value; }
        public List<ConsoleAndVersion> Consoles 
        { 
            get => _consoles; 
            set 
            { 
                _consoles = value; 
                OnPropertyChanged(nameof(Consoles)); 
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
        public List<ConsoleAndVersion> Versions
        {
            get => _versions;
            set {
                _versions = value; 
                OnPropertyChanged(nameof(Versions));
            }
        }

        public ConsoleAndVersion SelectedVersion
        {
            get => _selectedVersion;
            set
            {
                _selectedVersion = value;
                OnPropertyChanged(nameof(SelectedVersion));
                
            }
        }



        private string getComboBoxesConsoleName()
        {
            return SelectedConsole.Console + " " + SelectedVersion.Version;
        }

    }

    
}
