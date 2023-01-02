using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetEnnySarahLocationJeux.POCO;
using System.Windows.Input;
using System.Windows;

namespace ProjetEnnySarahLocationJeux.Viewmodels
{
    internal class AddNewConsoleViewModel : ViewModelBase
    {
        private ConsoleAndVersion _console;
        private string _errorMessage;
        public ICommand AddConsoleCommande { get; set; }


        public AddNewConsoleViewModel() { 
            _console = new ConsoleAndVersion();
            AddConsoleCommande = new ViewModelCommand(AddConsole);       
        }

        private void AddConsole(object obj)
        {
            if (Console.InsertConsole())
            {
                MessageBox.Show("New Console has been created");
            }
        }
        
        public ConsoleAndVersion Console { get => _console; set {  _console = value; OnPropertyChanged("Console");} }
        public string ErrorMessage { get => _errorMessage; set { _errorMessage = value; OnPropertyChanged("ErrorMessage"); } }

    }
}
