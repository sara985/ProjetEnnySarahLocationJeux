using ProjetEnnySarahLocationJeux.Viewmodels;
using ProjetEnnySarahLocationJeux.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProjetEnnySarahLocationJeux.Windows
{
    /// <summary>
    /// Logique d'interaction pour LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            DataContext = new LoginViewModel();

            IsVisibleChanged += (s, ev) =>
            {
                bool signup = ((LoginViewModel)DataContext).GoToSignup;
                bool admin = ((LoginViewModel)DataContext).IsLoginasAdmin;


                if (this.IsVisible == false && this.IsLoaded && signup == false && admin)
                {
                    var mainView = new AdminMainWindow();
                    mainView.Show();
                    this.Close();
                }
                else if (this.IsVisible == false && this.IsLoaded && signup == false)
                {
                    var mainView = new PlayerMainWindow();
                    mainView.Show();
                    this.Close();
                }
                else if (this.IsVisible == false && this.IsLoaded && signup == true)
                {
                    var mainView = new SignUpWindow();
                    mainView.Show();
                    this.Close();
                }
            };
        }
    }
}
