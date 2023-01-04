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
    internal class EditCreditViewModel : ViewModelBase
    {
        private VideoGame _game;
        private string _errorMessage;
        private List<VideoGame> _games;
        private VideoGame _selectedgame;
       

        public ICommand EditCreditCommand { get; set; }

        public EditCreditViewModel()
        {

            _game = new VideoGame();
            EditCreditCommand = new ViewModelCommand(EditCredit);
            Games = VideoGame.GetAll();
        }

        private void EditCredit(object obj)
        {
            int idG = getidgame();
            Game.Id=idG;
      
            if (Game.UpdateCredit())
            {
                MessageBox.Show("Cost has been modivied");
            }
        }

        private int getidgame()
        {
            return Selectedgame.Id;
        }

        public VideoGame Game { get => _game; set { _game = value; OnPropertyChanged(nameof(Game)); } }
        public string ErrorMessage { get => _errorMessage; set { _errorMessage = value; OnPropertyChanged(nameof(ErrorMessage)); } }
        public List<VideoGame> Games { get => _games; set { _games = value; OnPropertyChanged(nameof(Games)); } }
        public VideoGame Selectedgame { get => _selectedgame; set { _selectedgame = value; OnPropertyChanged(nameof(Selectedgame)); } }

        
    }
}
