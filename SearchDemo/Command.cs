using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SearchDemo
{
    public class Command : ICommand
    {
        private Action<object> action;
        private Func<object, bool> canExecute;

        public Command(Action<object> action)
        {
            this.action = action;
            this.canExecute = (object o) => { return true; };
        }

        public Command(Action<object> action, Func<object, bool> canExecute)
        {
            this.action = action;
            this.canExecute = canExecute;
        }

        #region ICommand Members

        public bool CanExecute(object parameter)
        {
            return canExecute(parameter);
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            action(parameter);
        }

        #endregion
    }
}
