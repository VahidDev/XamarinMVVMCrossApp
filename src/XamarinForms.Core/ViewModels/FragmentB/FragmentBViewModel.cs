using System;
using MvvmCross.Commands;
using System.Windows.Input;
using XamarinForms.Core.Navigation;

namespace XamarinForms.Core.ViewModels.FragmentB
{
    public class FragmentBViewModel : BaseViewModel
    {
        private int _counterB;
        private int _sharedCounter;
        private readonly INavigation _navigation;
        private readonly IGlobalModule _globalModule;

        public int CounterB
        {
            get => _counterB;
            set
            {
                _counterB = value;
                RaisePropertyChanged(() => CounterB);
            }
        }

        public int SharedCounter
        {
            get => _sharedCounter;
            set
            {
                _sharedCounter = value;
                RaisePropertyChanged(() => SharedCounter);
            }
        }

        public ICommand IncrementCounterCommand { get; set; }
        public ICommand IncrementSharedCounterCommand { get; set; }
        public ICommand GoToACommand { get; set; }
        public ICommand GoToCCommand { get; set; }
        public ICommand GoToDCommand { get; set; }
        public ICommand GoBackCommand { get; set; }

        public FragmentBViewModel
            ( INavigation navigation
            , IGlobalModule globalModule
            )
        {
            _navigation = navigation;
            _globalModule = globalModule;
            //_fragmentAViewModel = Mvx.IoCProvider.Resolve<FragmentAViewModel>();

            IncrementCounterCommand = new MvxCommand(IncrementCounter);
            IncrementSharedCounterCommand = new MvxCommand(IncrementSharedCounter);

            GoToACommand = new MvxCommand(GoToA);
            GoToCCommand = new MvxCommand(GoToC);
            GoToDCommand = new MvxCommand(GoToD);
            GoBackCommand = new MvxCommand(GoBack);
        }

        private void IncrementCounter() => CounterB++;
        private void IncrementSharedCounter() => SharedCounter++;

        private void GoBack() => throw new NotImplementedException();

        private void GoToD() => throw new NotImplementedException();

        private void GoToC() => throw new NotImplementedException();

        private void GoToA()
        {
            _navigation
        }
    }
}
