using Microsoft.VisualStudio.PlatformUI;
using Prism.Commands;
using ProjetEnnySarahLocationJeux.DAO;
using ProjetEnnySarahLocationJeux.Interfaces;
using ProjetEnnySarahLocationJeux.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;

namespace ProjetEnnySarahLocationJeux.Viewmodels
{
    public class RentGameViewModel : ViewModelBase, ICloseWindows
    {
        List<int> _numberOfWeeks;
        VideoGame _rentedVideoGame;
        int selectedNumberOfWeeks;
        DelegateCommand _closeCommand;

        public VideoGame RentedVideoGame { get => _rentedVideoGame; 
            set { _rentedVideoGame = value; OnPropertyChanged("RentedVideoGame"); }
        }

        public int SelectedNumberOfWeeks { get => selectedNumberOfWeeks;
            set { selectedNumberOfWeeks = value; OnPropertyChanged("SelectedNumberOfWeeks"); }
        }

        public ICommand CancelCommand { get; set; }
        public ICommand RentGameCommand { get; set; }
        public DelegateCommand CloseCommand =>
            _closeCommand ?? (_closeCommand = new DelegateCommand(CloseWindow));


        private void CloseWindow()
        {
            Close?.Invoke();
        }
        public Action Close { get; set; }
        public List<int> NumberOfWeeks { get => _numberOfWeeks; set
            {
                _numberOfWeeks = value; OnPropertyChanged("NumberOfWeeks");
            }                
        }

        public RentGameViewModel(VideoGame rentedVideoGame)
        {
            RentedVideoGame = rentedVideoGame;
            NumberOfWeeks = new List<int> {1,2,3,4};
            RentGameCommand = new ViewModelCommand(ExecuteRentGameCommand);
        }

        private void ExecuteRentGameCommand(object obj)
        {
            bool succes = Loan.StartLoan(RentedVideoGame, new PlayerDAO().GetByUsername(Thread.CurrentPrincipal.Identity.Name),
                SelectedNumberOfWeeks);
            string message;
            if (succes)
            {
                message = "You have succesfully rented " + RentedVideoGame.Name;
            }
            else message = "Error";
            MessageBox.Show(message);
            Close();
        }
    }
}
