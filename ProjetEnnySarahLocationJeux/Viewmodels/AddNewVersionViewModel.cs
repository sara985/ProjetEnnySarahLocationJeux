using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ProjetEnnySarahLocationJeux.POCO;

namespace ProjetEnnySarahLocationJeux.Viewmodels
{
    internal class AddNewVersionViewModel : ViewModelBase
    {
        private ConsoleAndVersion _version;
        private string _errorMessage;
        private List<ConsoleAndVersion> _consoles;
        private ConsoleAndVersion _selectedConsole;
        
      
        

        public ICommand AddVersionCommand { get; set; }

        public AddNewVersionViewModel() 
        {
            _version = new ConsoleAndVersion();
            AddVersionCommand = new ViewModelCommand(AddVersion);
            Consoles = ConsoleAndVersion.GetOnlyConsoles();
            
            
           
            
        }

        private void AddVersion(object obj)
        {
            int idc = getidcons();
            Version.IdConsole = idc;
            if (Version.InsertVersion())
            {
                MessageBox.Show("New Version has been created");
            } 
        }

      

        public ConsoleAndVersion Version
        {
            get => _version;
            set
            {
                _version = value;
                OnPropertyChanged(nameof(Version));
            }
        }

        public string ErrorMessage { get => _errorMessage; set => _errorMessage = value; }
        public List<ConsoleAndVersion> Consoles
        {
            get => _consoles;
            set
            {
                _consoles = value;
                OnPropertyChanged(nameof(Consoles));
            }
        }
        public ConsoleAndVersion SelectedConsole{get => _selectedConsole;set{_selectedConsole = value; OnPropertyChanged(nameof(SelectedConsole));}}

        private int getidcons()
        {
            return SelectedConsole.IdConsole;
        }
 
    }
}
