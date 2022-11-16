﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

namespace ProjetEnnySarahLocationJeux.CustomControls
{
    /// <summary>
    /// Logique d'interaction pour BindablePasswordBox.xaml
    /// </summary>
    public partial class BindablePasswordBox : UserControl
    {
        public static readonly DependencyProperty PasswordProperty = 
            DependencyProperty.Register("Password", typeof(string), typeof(BindablePasswordBox));

        public string Password {
        
            get { return (string)GetValue(PasswordProperty); }
            set { SetValue(PasswordProperty, value); }

        }

        public BindablePasswordBox()
        {
            InitializeComponent();
            passwordBox.PasswordChanged += OnPasswordChanged;
        }

        private void OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            Password = passwordBox.Password;
        }
    }
}
