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

        public Copy Game { get { return _game; } 
            set { 
                _game = value; 
                OnPropertyChanged(nameof(Game));
            }
        }

        public ICommand AddGameCommand { get; set; }

        public AddGameViewModel()
        {
            AddGameCommand = new ViewModelCommand(ExecuteAddGameCommand);
        }

        private void ExecuteAddGameCommand(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
