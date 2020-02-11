using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Spg.TicketShop.WpfBackEnd.Services
{
    public class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public readonly Func<object, bool> canExecute;
        public readonly Action<object> execute;

        public RelayCommand(Action<object> execute, object signInCanExecute)
            : this(execute, null)
        { }

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute)
        {
            this.canExecute = canExecute;
            this.execute = execute;
        }

        public bool CanExecute(object parameter)
        {
            if (parameter == null)
            {
                return true;
            }
            return canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            if (parameter != null)
            {
                execute(parameter);
            }
        }
    }
}
