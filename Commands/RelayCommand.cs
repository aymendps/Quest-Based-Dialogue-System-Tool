using System.Windows.Input;

namespace QuestBasedDialogueSystemTool.Commands
{
    class RelayCommand<T> : ICommand
    {
        private readonly Action<T> _execute;
        private readonly Predicate<T> _canExecute;

        /// <summary>
        /// Creates a new command that can always execute.
        /// </summary>
        /// <param name="execute">The execution logic of the command.</param>
        public RelayCommand(Action<T> execute) : this(execute, new Predicate<T>((T obj) => true))
        {
        }

        /// <summary>
        /// Creates a new command.
        /// </summary>
        /// <param name="execute">The execution logic of the command.</param>
        /// <param name="canExecute">The status logic of the command.</param>
        public RelayCommand(Action<T> execute, Predicate<T> canExecute)
        {
            ArgumentNullException.ThrowIfNull(execute);
            ArgumentNullException.ThrowIfNull(canExecute);

            _execute = execute;
            _canExecute = canExecute;
        }

        /// <summary>
        /// Determines whether the command can execute or not.
        /// </summary>
        /// <param name="parameter">Data used by the command. Can be passed as null if it's not needed by the command.</param>
        /// <returns></returns>
        public bool CanExecute(object? parameter)
        {
            return _canExecute((T)parameter);
        }

        /// <summary>
        /// Is invoked when changes occur that affect whether the command should execute.
        /// </summary>
        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        /// <summary>
        /// Executes the command's logic.
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object? parameter)
        {
            _execute((T)parameter);
        }
    }
}
