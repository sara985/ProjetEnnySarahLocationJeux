using ProjetEnnySarahLocationJeux.Interfaces;
using ProjetEnnySarahLocationJeux.POCO;
using ProjetEnnySarahLocationJeux.Viewmodels;
using System.Windows;

namespace ProjetEnnySarahLocationJeux.SmallWindows
{
    /// <summary>
    /// Logique d'interaction pour RentGameWindow.xaml
    /// </summary>
    public partial class RentGameWindow : Window
    {
        public RentGameWindow(VideoGame obj)
        {
            InitializeComponent();
            this.DataContext = new RentGameViewModel(obj);
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
