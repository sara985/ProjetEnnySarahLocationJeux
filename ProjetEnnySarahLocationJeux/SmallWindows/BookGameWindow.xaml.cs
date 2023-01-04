using ProjetEnnySarahLocationJeux.Interfaces;
using ProjetEnnySarahLocationJeux.POCO;
using ProjetEnnySarahLocationJeux.Viewmodels;
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

namespace ProjetEnnySarahLocationJeux.SmallWindows
{
    /// <summary>
    /// Logique d'interaction pour BookGameWindow.xaml
    /// </summary>
    public partial class BookGameWindow : Window
    {
        public BookGameWindow(VideoGame bookedGame)
        {
            InitializeComponent();
            this.DataContext = new BookGameViewModel(bookedGame);
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

