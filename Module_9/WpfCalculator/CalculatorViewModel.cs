using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace WpfCalculator
{
    public class RelayCommand : ICommand
    {
        #region Fields 
        readonly Action<object> _execute;
        readonly Predicate<object> _canExecute;
        #endregion // Fields 
        #region Constructors 
        public RelayCommand(Action<object> execute) : this(execute, null) { }
        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");
            _execute = execute; _canExecute = canExecute;
        }
        #endregion // Constructors 
        #region ICommand Members 
        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }
        public event EventHandler CanExecuteChanged
        {
            add { }
            remove { }
        }
        public void Execute(object parameter) { _execute(parameter); }
        #endregion // ICommand Members 
    }
    public class CalculatorViewModel : INotifyPropertyChanged
    {
        private int a = 23;
        private int b = 19;
        private int result;

        public int Result
        {
            get { return result; }
            set 
            { 
                result = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Result)));
            }
        }

        public int B
        {
            get { return b; }
            set 
            { 
                b = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(B)));
            }
        }
        public int A
        {
            get { return a; }
            set 
            { 
                a = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(A)));
            }
        }

        private RelayCommand relayAddCommand;

        public ICommand AddCommand
        {
            get 
            {
                if (relayAddCommand == null)
                {
                    relayAddCommand = new RelayCommand(par => Result = A + B , null);
                }
                return relayAddCommand;
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
    }
}
