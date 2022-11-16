using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProjetEnnySarahLocationJeux.Viewmodels
{                
    public class ViewModelCommand : ICommand
    {
        //Fields of type action to execute the command
        private readonly Action<object> _executeAction;
        //determine if the action can be executed or not
        private readonly Predicate<object> _canExecuteAction;

        //Constructors
        public ViewModelCommand(Action<object> executeAction)
        {
            _executeAction = executeAction;
            _canExecuteAction = null;
        }

        public ViewModelCommand(Action<object> executeAction, Predicate<object> canExecuteAction)
        {
            _executeAction = executeAction;
            _canExecuteAction = canExecuteAction;
        }

        //Events, detects if canExecute has changed
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        //Methods
        public bool CanExecute(object parameter)
        {
            return _canExecuteAction == null ? true : _canExecuteAction(parameter);
        }

        public void Execute(object parameter)
        {
            //if canExecute is null that means you can always execute
            _executeAction(parameter);
        }
    }
}        
 