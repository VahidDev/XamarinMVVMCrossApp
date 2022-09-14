using System;
using MvvmCross.Commands;
using System.Windows.Input;

namespace XamarinForms.Core.ViewModels.FragmentD
{
    public class FragmentDViewModel : BaseViewModel
    {
        private int _counterD;
        public int CounterD
        {
            get => _counterD;
            set
            {
                _counterD = value;
                RaisePropertyChanged(() => CounterD);
            }
        }
        
        public ICommand IncrementCounterCommand { get; set; }
        public ICommand GoToBCommand { get; set; }
        public ICommand GoToCCommand { get; set; }
        public ICommand GoToACommand { get; set; }
        public ICommand GoBackCommand { get; set; }

        public FragmentDViewModel()
        {
            IncrementCounterCommand = new MvxCommand(IncrementCounter);

            GoToACommand = new MvxCommand(GoToA);
            GoToBCommand = new MvxCommand(GoToB);
            GoToCCommand = new MvxCommand(GoToC);
            GoBackCommand = new MvxCommand(GoBack);
        }

        private void IncrementCounter() => CounterD++;

        private void GoBack() => throw new NotImplementedException();

        private void GoToA() => throw new NotImplementedException();

        private void GoToC() => throw new NotImplementedException();

        private void GoToB() => throw new NotImplementedException();
    }
}
