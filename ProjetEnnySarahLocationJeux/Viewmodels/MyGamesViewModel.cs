using ProjetEnnySarahLocationJeux.DAO;
using ProjetEnnySarahLocationJeux.POCO;
using ProjetEnnySarahLocationJeux.POCO_MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows;
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
            SelectedLoan.EndLoan();
            //Refresh Loan list
            RentedGames = Loan.GetOngoingLoansForUser(CurrentUser.Id);
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
