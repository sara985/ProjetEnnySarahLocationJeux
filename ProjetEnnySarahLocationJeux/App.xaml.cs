using ProjetEnnySarahLocationJeux.Viewmodels;
using ProjetEnnySarahLocationJeux.Views;
using ProjetEnnySarahLocationJeux.Windows;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ProjetEnnySarahLocationJeux
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected void ApplicationStart(object sender, StartupEventArgs e)
        {
            var loginView = new LoginWindow();
            loginView.Show();
            loginView.IsVisibleChanged += (s, ev) =>
            {
                bool signup = ((LoginViewModel)loginView.DataContext).GoToSignup;
                bool admin = ((LoginViewModel)loginView.DataContext).IsLoginasAdmin;


               if (loginView.IsVisible == false && loginView.IsLoaded && signup == false && admin)
                {
                    var mainView = new AdminMainWindow();
                    mainView.Show();
                    loginView.Close();
                }
               else if (loginView.IsVisible == false && loginView.IsLoaded && signup==false)
                {
                    var mainView = new PlayerMainWindow();
                    mainView.Show();
                    loginView.Close();
                }else if (loginView.IsVisible == false && loginView.IsLoaded && signup == true)
                {
                    var mainView = new SignUpWindow();
                    mainView.Show();
                    loginView.Close();
                }
            };
            //if current window = signup or if current datacontext = SignUpViewModel
            
        }
    }
}
