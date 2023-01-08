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
        }
    }
}
