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
    internal class DeleteGameViewModel: ViewModelBase
    {
        private VideoGame _game;
        private string _errorMessage;
        private List<VideoGame> _games;
        private VideoGame _selectedgame;

        public ICommand DeleteGameCommand { get; set; }

        public DeleteGameViewModel()
        {
            _game = new VideoGame();
            DeleteGameCommand = new ViewModelCommand(DeleteGame);
            Games = VideoGame.NonusedGames();
        }

        private void DeleteGame(object obj)
        {
            Game.Id=Selectedgame.Id;
            if (Game.DeleteUnusedGame())
            {
                MessageBox.Show("Game has been deleted");
            }
        }

        public VideoGame Game { get => _game; set { _game = value; OnPropertyChanged(nameof(Game)); } }
        public string ErrorMessage { get => _errorMessage; set { _errorMessage = value; OnPropertyChanged(nameof(ErrorMessage)); } }
        public List<VideoGame> Games { get => _games; set { _games = value; OnPropertyChanged(nameof(Games)); } }
        public VideoGame Selectedgame { get => _selectedgame; set { _selectedgame = value; OnPropertyChanged(nameof(Selectedgame)); } }



    }
}
