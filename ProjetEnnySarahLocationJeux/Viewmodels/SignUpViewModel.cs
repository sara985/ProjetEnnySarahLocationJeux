using ProjetEnnySarahLocationJeux.DAO;
using ProjetEnnySarahLocationJeux.Interfaces;
using ProjetEnnySarahLocationJeux.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ProjetEnnySarahLocationJeux.Viewmodels
{
    internal class SignUpViewModel : ViewModelBase
    {
        private Player _player;
        private string _errorMessage;
        private bool _isViewVisible;
        private DateTime _selectedDate;

        public string ErrorMessage { get => _errorMessage; set { _errorMessage = value; OnPropertyChanged("ErrorMessage"); } }
        public bool IsViewVisible { get => _isViewVisible; set { _isViewVisible = value; OnPropertyChanged("IsViewVisible"); } }
        public Player Player { get => _player; 
            set { _player = value; 
                OnPropertyChanged("Player"); } }
    
        public DateTime SelectedDate { get => _selectedDate; set => _selectedDate = value; }
        public ICommand VerifyUsernameCommand { get; set; }
        public ICommand VerifyPasswordCommand { get; set; }
        public ICommand AddPlayerCommand { get; set; }

        public SignUpViewModel()
        {
            _player = new Player();
            VerifyUsernameCommand = new ViewModelCommand(p => VerifyUsername(""));
            AddPlayerCommand = new ViewModelCommand(AddPlayer);
            SelectedDate = new DateTime(2000, 01, 01);
        }

        private void AddPlayer(object obj)
        {
            Player.BirthDate = DateOnly.FromDateTime(SelectedDate);
            Player.SignUpDate = DateOnly.FromDateTime(DateTime.Now);
            Player.Balance = 10;
            Player.CalculateSHA256();
            DateOnly birthdayThisYear = DateOnly.FromDateTime(new DateTime(DateTime.Now.Year, Player.BirthDate.Month, Player.BirthDate.Day));
            //Comparer la signupdate et sa date d'anniversaire
            if (birthdayThisYear.CompareTo(DateOnly.FromDateTime(DateTime.Now)) > 0) //Has not had birthday yet
            {
                Player.HadBirthdayCredit = false;
            }
            else
            {
                Player.HadBirthdayCredit = true;
            }
            if (Player.Insert())
            {
                MessageBox.Show("Your account was created succesfully. You can now login.");
                IsViewVisible = false;
            }
            else
            {
                MessageBox.Show("There's been a problem. Please fill out all fields.");
            }
        }

        private bool VerifyUsername(object obj)
        {
            bool isAvailable;
            if (true) //TODO search username in DB and return true or false
            {
                return true;
            }
        }
    }
}
