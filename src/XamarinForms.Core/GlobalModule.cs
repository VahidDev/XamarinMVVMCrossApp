using System.ComponentModel;
using System.Windows.Input;
using MvvmCross.Commands;
using XamarinForms.Core.ViewModels;

namespace XamarinForms.Core
{
    public class GlobalModule
        : IGlobalModule 
        , INotifyPropertyChanged
    {
        private int _counter;

        public event PropertyChangedEventHandler PropertyChanged;

        public int Counter
        {
            get => _counter;
            set
            {
                _counter = value;
                OnPropertyCHanged();
            }
        }

        public ICommand IncrementCounterCommand { get; set; }

        public GlobalModule()
        {
            IncrementCounterCommand = new MvxCommand(IncrementCounter);
        }

        private void IncrementCounter() => Counter++;

        public void OnPropertyCHanged()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Counter)));
        }
    }
}
