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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjetEnnySarahLocationJeux.Pages
{
    /// <summary>
    /// Logique d'interaction pour Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }

        private void logInClick(object sender, RoutedEventArgs e)
        {
            if (loginBox.Text.Trim() == "" || passwordBox.Password.Trim() == "")
            {
                errortxt.Text = "Please fill in your email and password";
            }
        }
    }
}
