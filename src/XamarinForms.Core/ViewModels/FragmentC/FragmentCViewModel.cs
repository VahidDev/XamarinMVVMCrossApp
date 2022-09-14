using System;
using System.Collections.Generic;
using System.Text;
using MvvmCross.Commands;
using System.Windows.Input;

namespace XamarinForms.Core.ViewModels.FragmentC
{
    public class FragmentCViewModel : BaseViewModel
    {
        private int _counterC;
        public int CounterC
        {
            get => _counterC;
            set
            {
                _counterC = value;
                RaisePropertyChanged(() => CounterC);
            }
        }
        
        public ICommand IncrementCounterCommand { get; set; }
        public ICommand GoToCAommand { get; set; }
        public ICommand GoToBCommand { get; set; }
        public ICommand GoToDCommand { get; set; }
        public ICommand GoBackCommand { get; set; }

        public FragmentCViewModel()
        {
            IncrementCounterCommand = new MvxCommand(IncrementCounter);

            GoToCAommand = new MvxCommand(GoToA);
            GoToBCommand = new MvxCommand(GoToB);
            GoToDCommand = new MvxCommand(GoToD);
            GoBackCommand = new MvxCommand(GoBack);
        }

        private void IncrementCounter() => CounterC++;

        private void GoBack() => throw new NotImplementedException();

        private void GoToD() => throw new NotImplementedException();

        private void GoToA() => throw new NotImplementedException();

        private void GoToB() => throw new NotImplementedException();
    }
}
