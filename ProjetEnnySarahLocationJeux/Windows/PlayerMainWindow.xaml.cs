using ProjetEnnySarahLocationJeux.CustomControls;
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

namespace ProjetEnnySarahLocationJeux.Views
{
    /// <summary>
    /// Logique d'interaction pour PlayerMainWindow.xaml
    /// </summary>
    public partial class PlayerMainWindow : Window
    {
        public PlayerMainWindow()
        {
            InitializeComponent();
        }

        private void sidebar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //cast selected item as NavButton
            var selected = sidebar.SelectedItem as NavButton;

            navFrame.Navigate(selected.NavLink);
        }
    }
}
