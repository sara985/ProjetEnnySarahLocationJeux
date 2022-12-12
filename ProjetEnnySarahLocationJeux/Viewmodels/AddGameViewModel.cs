using ProjetEnnySarahLocationJeux.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProjetEnnySarahLocationJeux.Viewmodels
{
    internal class AddGameViewModel : ViewModelBase
    {
        private Copy _game;
        private List<ConsoleAndVersion> _consoles;
        private ConsoleAndVersion _selectedConsole;
        private List<ConsoleAndVersion> _versions;

        public Copy Game { get { return _game; } 
            set { 
                _game = value; 
                OnPropertyChanged(nameof(Game));
            }
        }

        public ICommand AddGameCommand { get; set; }
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

        public ConsoleAndVersion SelectedConsole { get => _selectedConsole;
            set
            {
                _selectedConsole = value;
                OnPropertyChanged(nameof(SelectedConsole));
                Versions = ConsoleAndVersion.GetVersionsByConsole(SelectedConsole.IdConsole);
            }
        }

        public AddGameViewModel()
        {
            AddGameCommand = new ViewModelCommand(ExecuteAddGameCommand);
            Consoles = ConsoleAndVersion.GetAllConsoles();
        }

        private void ExecuteAddGameCommand(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
