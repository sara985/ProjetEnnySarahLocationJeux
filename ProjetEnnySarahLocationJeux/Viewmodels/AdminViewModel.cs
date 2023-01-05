using ProjetEnnySarahLocationJeux.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ProjetEnnySarahLocationJeux.POCO;

namespace ProjetEnnySarahLocationJeux.Viewmodels
{
    internal class AdminViewModel : ViewModelBase
    {
        private Administrator _currentAdmin;

        public ICommand SignOutCommand { get; set; }
        public AdminViewModel() 
        { 
            LoadCurrentUserData();
            SignOutCommand = new ViewModelCommand(SignOut);
        }

        private void SignOut(object obj)
        {
            MessageBox.Show("SignOut");
        }

        public Administrator CurrentAdmin
        {
            get { return _currentAdmin; }
            set { _currentAdmin = value; OnPropertyChanged("CurrentAdmin"); }
        }

        

        private void LoadCurrentUserData()
        {
            Administrator a = Administrator.GetAdminByUsername(Thread.CurrentPrincipal.Identity.Name);
            if (a != null)
            {
                _currentAdmin = a;
            }
        }

    }
}
