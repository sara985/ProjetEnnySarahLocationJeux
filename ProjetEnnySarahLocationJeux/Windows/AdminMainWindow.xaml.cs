using ProjetEnnySarahLocationJeux.CustomControls;
using ProjetEnnySarahLocationJeux.Windows;
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

namespace ProjetEnnySarahLocationJeux.Views
{
    /// <summary>
    /// Interaction logic for AdminMainWindow.xaml
    /// </summary>
    public partial class AdminMainWindow : Window
    {
        public AdminMainWindow()
        {
            InitializeComponent();
        }

        private void sidebar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //cast selected item as NavButton
            var selected = adminsidebar.SelectedItem as NavButton;

            navFrame.Navigate(selected.NavLink);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //NavigationService.Navigate(new Uri("LoginWindow.xaml", UriKind.Relative));
            //Frame.Navigate(new Uri("LoginWindow.xaml", UriKind.Relative));
            new LoginWindow().Show();
            this.Close();
        }
    }
}

