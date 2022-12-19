using ProjetEnnySarahLocationJeux.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjetEnnySarahLocationJeux.Viewmodels
{
    internal class AdminViewModel : ViewModelBase
    {
        private Administrator _currentAdmin;

        public Administrator CurrentAdmin
        {
            get { return _currentAdmin; }
            set { _currentAdmin = value; OnPropertyChanged("CurrentAdmin"); }
        }

        public AdminViewModel() { LoadCurrentUserData(); }

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
