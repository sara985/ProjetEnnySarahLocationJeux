using ProjetEnnySarahLocationJeux.DAO;
using ProjetEnnySarahLocationJeux.POCO;
using ProjetEnnySarahLocationJeux.POCO_MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProjetEnnySarahLocationJeux.Viewmodels
{
    public class MyGamesViewModel : ViewModelBase
    {
        Player _currentUser;
        List<Loan> _rentedGames;
        List<Booking> _bookedGames;
        List<VideoGame> _ownedGames;
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
            BookedGames = Booking.GetBookedCopiesForUser(CurrentUser.Id);
            RentedGames = Loan.GetOngoingLoansForUser(CurrentUser.Id);
            Status = Enum.GetValues(typeof(Status)).Cast<Status>().ToList();
            CancelBookingCommand = new ViewModelCommand(ExecuteCancelBooking);
            EndLoanCommand = new ViewModelCommand(ExecuteEndLoan, CanExecuteEndLoan);
            LoanStatus = new List<string>() { "ongoing", "Finished" };
        }

        private bool CanExecuteEndLoan(object obj)
        {
            if (SelectedLoan is not null && SelectedLoan.EffectiveEndDate.HasValue) return false;
            return true;
        }

        private void ExecuteEndLoan(object obj)
        {
            SelectedLoan.EndLoan();
        }

        private void ExecuteCancelBooking(object obj)
        {
            SelectedBooking.Status = POCO_MODELS.Status.Canceled;
            SelectedBooking.UpdateStatus();
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
                SelectedLoan = RentedGames.First();
            }
        }
    }
}
