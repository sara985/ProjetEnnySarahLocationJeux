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
    /// Logique d'interaction pour SignUpWindow.xaml
    /// </summary>
    public partial class SignUpWindow : Window
    {
        public SignUpWindow()
        {
            //bug quand ferme windows avec la croix
            InitializeComponent();
            this.IsVisibleChanged += (s, ev) =>
            {
                if (this.IsLoaded && this.IsVisible==false)
                {
                    new LoginWindow().Show();
                    this.Close();
                }
            };
        }
    }
}
