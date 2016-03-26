// NO LICENSE
// ==========
// There is no copyright, you can use and abuse this source without limit.
// There is no warranty, you are responsible for the consequences of your use of this source.
// There is no burden, you do not need to acknowledge this source in your use of this source.

namespace guidgen
{
    using System;
    using System.Windows.Input;

    internal class SimpleCommand : ICommand
    {
        private Action onExecute;

        public SimpleCommand(Action onExecute)
        {
            this.onExecute = onExecute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this.onExecute();
        }
    }
}