using MessagePack.Formatters;
using ProjetEnnySarahLocationJeux.DAO;
using ProjetEnnySarahLocationJeux.POCO;
using ProjetEnnySarahLocationJeux.POCO_MODELS;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ProjetEnnySarahLocationJeux.Viewmodels
{
    public class MyGamesViewModel : ViewModelBase
    {
        Player _currentUser;
        List<Loan> _rentedGames;
        List<Booking> _bookedGames;
        List<Copy> _ownedGames;
        Copy _selectedOwnedGame;
        List<Status> _status;
        Status _selectedStatus;
        Booking _selectedBooking;
        Loan _selectedLoan;
        List<string> _loanStatus;
        string _selectedLoanStatus;

        public MyGamesViewModel()
        {
            CurrentUser = new PlayerDAO().GetByUsername(Thread.CurrentPrincipal.Identity.Name);
            RentedGames = new List<Loan>();
            BookedGames = Booking.GetBookingsByStatusAndUser(SelectedStatus, CurrentUser.Username);
            RentedGames = Loan.GetOngoingLoansForUser(CurrentUser.Id);
            Status = Enum.GetValues(typeof(Status)).Cast<Status>().ToList();
            CancelBookingCommand = new ViewModelCommand(ExecuteCancelBooking, CanEexecuteCancelBooking);
            EndLoanCommand = new ViewModelCommand(ExecuteEndLoan, CanExecuteEndLoan);
            LoanStatus = new List<string>() { "ongoing", "finished" };
            SelectedLoanStatus = LoanStatus.First();
            OwnedGames = Copy.GetAll().Where(c => c.Owner.Id == CurrentUser.Id).ToList();
            DeleteOwnedGame = new ViewModelCommand(ExecuteDeleteOwnedGame);
            SelectedLoan = RentedGames.FirstOrDefault();
        }

        private bool CanEexecuteCancelBooking(object obj)
        {
            if (SelectedBooking == null) return false;
            if(SelectedBooking.Status == POCO_MODELS.Status.Waiting) return true;
            return false;
        }

        private void ExecuteDeleteOwnedGame(object obj)
        {
            //Verify if copy is booked or loaned
            if (SelectedOwnedGame.Bookings.Where(b => b.Status==POCO_MODELS.Status.Waiting).Count() == 0 && SelectedOwnedGame.IsAvailable)
            {
                SelectedOwnedGame.Delete();
                OwnedGames = Copy.GetAll().Where(c => c.Owner.Id == CurrentUser.Id).ToList();
                MessageBox.Show("Your game was succesfully deleted.");
            }
            else
            {
                //Tell the user they can't delete their game
                MessageBox.Show("Your game is currently booked or loaned. Please contact the administrator.");
            }
        }

        private bool CanExecuteEndLoan(object obj)
        {
            if (SelectedLoan is not null && SelectedLoan.EffectiveEndDate.HasValue) return false;
            return true;
        }

        private void ExecuteEndLoan(object obj)
        {
            Loan oldLoan = SelectedLoan;
            SelectedLoan.EndLoan();
            //The game is Available, check if someone is waiting for it
            List<Booking> books = oldLoan.Copy.Game.GetWaitingBooking();
            if (books.Any()) //There is a waiting booking, we need to create a new loan
            {
                Booking bookToLoan = new Booking();
                // Waiting bookings must be ordered by booker with the biggest balance, then by the oldest booking, then by the longest user, then by the oldest user
                books = books.OrderByDescending(b => b.Booker.Balance).ThenBy(b => b.BookingDate).ThenBy(b => b.Booker.SignUpDate).ThenBy(b => b.Booker.BirthDate).ToList();
                if (books[0].Equals(books[1])) //At least two games could potentially have the place, we have to choose randomly
                {
                    books = books.Where(b => books[0].Equals(b)).ToList();
                    Random rnd = new Random();
                    int index = rnd.Next(0, books.Count); // Generate a random index between 0 and the number of elements in the list
                    bookToLoan = books.ElementAt(index); // Select the element at the randomly generated index
                }
                else
                { //sinon on prend le premier booking de la liste puisque la liste est triée
                    bookToLoan = books[0];           
                    
                }
                //insert new loan
                Loan.StartLoan(bookToLoan.Game, bookToLoan.Booker, bookToLoan.Duration, oldLoan.Copy);
                //Update the booking status
                bookToLoan.Status = POCO_MODELS.Status.Booked;
                bookToLoan.UpdateStatus();                
                MessageBox.Show("The loan was succesfully ended");
        }
            //Update the view
            BookedGames = Booking.GetBookingsByStatusAndUser(SelectedStatus, CurrentUser.Username);
            RentedGames = Loan.GetOngoingLoansForUser(CurrentUser.Id);
            CurrentUser=new PlayerDAO().GetById(CurrentUser.Id);
            MessageBox.Show("You gave back the game. Your current balance is now : "+CurrentUser.Balance);
        }

        private void ExecuteCancelBooking(object obj)
        {
            SelectedBooking.Status = POCO_MODELS.Status.Canceled;
            SelectedBooking.UpdateStatus();
            BookedGames = Booking.GetBookingsByStatusAndUser(SelectedStatus, CurrentUser.Username);
            SelectedBooking = BookedGames.FirstOrDefault();
            MessageBox.Show("Your booking was succesfully canceled.");
        }

        public List<Loan> RentedGames { 
            get => _rentedGames;
            set
            {
                _rentedGames = value;
                OnPropertyChanged("RentedGames");
            }
        }

        public List<Status> Status { get => _status; set => _status = value; }
        public Status SelectedStatus { get => _selectedStatus;
            set
            {
                 _selectedStatus = value;
                OnPropertyChanged("SelectedStatus");
                BookedGames = Booking.GetBookingsByStatusAndUser(SelectedStatus, Thread.CurrentPrincipal.Identity.Name);
            }
        }

        public ICommand CancelBookingCommand { get; set; }
        public ICommand EndLoanCommand { get; set; }
        public ICommand DeleteOwnedGame { get; set; }
        public List<Booking> BookedGames
        {
            get => _bookedGames;
            set
            {
                _bookedGames = value;
                OnPropertyChanged("BookedGames");
            }
        }

        public Booking SelectedBooking { get => _selectedBooking; set { _selectedBooking = value;
                OnPropertyChanged("SelectedBooking");
            } }

        public Player CurrentUser { get => _currentUser; set => _currentUser = value; }
        public Loan SelectedLoan { get => _selectedLoan; set => _selectedLoan = value; }
        public List<string> LoanStatus { get => _loanStatus; set => _loanStatus = value; }
        public string SelectedLoanStatus
        {
            get => _selectedLoanStatus;
            set
            {
                _selectedLoanStatus = value;
                OnPropertyChanged("SelectedLoanStatus");
                if (SelectedLoanStatus == "ongoing")
                {
                    RentedGames = Loan.GetOngoingLoansForUser(CurrentUser.Id);
                }
                else
                {
                    RentedGames = Loan.GetFinishedLoansForUser(CurrentUser.Id);
                }
                if(RentedGames.Count!=0)
                SelectedLoan = RentedGames.First();
            }
        }

        public List<Copy> OwnedGames { get => _ownedGames;
            set
            {
                _ownedGames = value;
                OnPropertyChanged("OwnedGames");
            }
        }
        public Copy SelectedOwnedGame { get => _selectedOwnedGame;
            set
            {
                _selectedOwnedGame = value;
                OnPropertyChanged("SelectedOwnedGame");
            }
                }
    }
}
