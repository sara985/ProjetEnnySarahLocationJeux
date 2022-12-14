using ProjetEnnySarahLocationJeux.CustomControls;
using ProjetEnnySarahLocationJeux.Interfaces;
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
            Loaded += WindowLoaded;
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            if (DataContext is ICloseWindows vm)
            {
                vm.Close += () =>
                {
                    this.Close();
                };
            }
        }
    }
}
