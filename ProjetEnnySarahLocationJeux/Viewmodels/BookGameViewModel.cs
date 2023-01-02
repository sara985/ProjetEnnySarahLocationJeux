using Prism.Commands;
using ProjetEnnySarahLocationJeux.DAO;
using ProjetEnnySarahLocationJeux.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace ProjetEnnySarahLocationJeux.Viewmodels
{
    public class BookGameViewModel : ViewModelBase
    {
        List<int> _numberOfWeeks;
        VideoGame _bookedVideoGame;
        int selectedNumberOfWeeks;
        DelegateCommand _closeCommand;

        public VideoGame BookedVideoGame
        {
            get => _bookedVideoGame;
            set { _bookedVideoGame = value; OnPropertyChanged("BookedVideoGame"); }
        }

        public int SelectedNumberOfWeeks
        {
            get => selectedNumberOfWeeks;
            set { selectedNumberOfWeeks = value; OnPropertyChanged("SelectedNumberOfWeeks"); }
        }

        public ICommand CancelCommand { get; set; }
        public ICommand BookGameCommand { get; set; }
        public DelegateCommand CloseCommand =>
            _closeCommand ?? (_closeCommand = new DelegateCommand(CloseWindow));


        private void CloseWindow()
        {
            Close?.Invoke();
        }
        public Action Close { get; set; }
        public List<int> NumberOfWeeks
        {
            get => _numberOfWeeks; set
            {
                _numberOfWeeks = value; OnPropertyChanged("NumberOfWeeks");
            }
        }

        public BookGameViewModel(VideoGame bookedVideoGame)
        {
            BookedVideoGame = bookedVideoGame;
            NumberOfWeeks = new List<int> { 1, 2, 3, 4 };
            BookGameCommand = new ViewModelCommand(ExecuteBookGameCommand);
        }

        private void ExecuteBookGameCommand(object obj)
        {
            bool succes = Loan.StartLoan(BookedVideoGame, new PlayerDAO().GetByUsername(Thread.CurrentPrincipal.Identity.Name),
                SelectedNumberOfWeeks);
            string message;
            if (succes)
            {
                //message = "You have succesfully rented " + RentedVideoGame.Name;
            }
            else message = "Error";
            //MessageBox.Show(message);
            Close();
        }
    }
}
