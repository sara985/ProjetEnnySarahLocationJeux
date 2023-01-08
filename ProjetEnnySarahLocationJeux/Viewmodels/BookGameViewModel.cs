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
using ProjetEnnySarahLocationJeux.Interfaces;
using ProjetEnnySarahLocationJeux.POCO_MODELS;

namespace ProjetEnnySarahLocationJeux.Viewmodels
{
    public class BookGameViewModel : ViewModelBase, ICloseWindows
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
            set { selectedNumberOfWeeks = value; 
                OnPropertyChanged("SelectedNumberOfWeeks"); }
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
                _numberOfWeeks = value; 
                OnPropertyChanged("NumberOfWeeks");
            }
        }

        public BookGameViewModel(VideoGame bookedVideoGame)
        {
            BookedVideoGame = bookedVideoGame;
            NumberOfWeeks = new List<int> { 1, 2, 3, 4 };
            BookGameCommand = new ViewModelCommand(ExecuteBookGameCommand);
            SelectedNumberOfWeeks = 1;
        }

        private void ExecuteBookGameCommand(object obj)
        {
            Booking b = new();
            b.Status = Status.Waiting;
            b.Duration = SelectedNumberOfWeeks;
            b.BookingDate = DateOnly.FromDateTime(DateTime.Now);
            b.Booker = new PlayerDAO().GetByUsername(Thread.CurrentPrincipal.Identity.Name);
            //order the copies by the minimum amount of bookings so the user potentially waits less time
            //Ne fonctionne que s'il y a déjà des bookings, sinon n'est pas repris dans la requête
            b.Game = BookedVideoGame;
            bool succes = b.Insert();
            string message;
            if (succes)
            {
                message = "You have succesfully booked " + BookedVideoGame.Name + ". You can now see it under My Games section.";
            }
            else message = "Error";
            MessageBox.Show(message);
            Close();
        }
    }
}
