using System;
using MvvmCross.Commands;
using System.Windows.Input;
using MvvmCross.Navigation;
using XamarinForms.Core.ViewModels.FragmentB;
using MvvmCross;

namespace XamarinForms.Core.ViewModels.FragmentA
{
    public class FragmentAViewModel : BaseViewModel
    {

        private int _sharedCounter;
        private readonly IMvxNavigationService _mvxNavigationService;
        private readonly FragmentBViewModel _fragmentBViewModel;
        private int _counterA;

        public int CounterA
        {
            get => _counterA;
            set
            {
                _counterA = value;
                RaisePropertyChanged(() => CounterA);
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
        public ICommand GoToBCommand { get; set; }
        public ICommand GoToCCommand { get; set; }
        public ICommand GoToDCommand { get; set; }
        public ICommand GoBackCommand { get; set; }

        public FragmentAViewModel
            ( IGlobalModule globalModule
            , IMvxNavigationService mvxNavigationService
            
            )
        {
            _sharedCounter = globalModule.Counter;
            _mvxNavigationService = mvxNavigationService;
            //_fragmentBViewModel = Mvx.IoCProvider.Resolve<FragmentBViewModel>();

            IncrementCounterCommand = new MvxCommand(IncrementCounter);
            IncrementSharedCounterCommand = new MvxCommand(IncrementSharedCounter);

            GoToBCommand = new MvxCommand(GoToB);
            GoToCCommand = new MvxCommand(GoToC);
            GoToDCommand = new MvxCommand(GoToD);
            GoBackCommand = new MvxCommand(GoBack);
        }

        private void IncrementCounter() => CounterA++;
        private void IncrementSharedCounter() => SharedCounter++;

        private void GoBack() => throw new NotImplementedException();

        private void GoToD() => throw new NotImplementedException();

        private void GoToC() => throw new NotImplementedException();

        private void GoToB()
        {
            _mvxNavigationService.Navigate(_fragmentBViewModel);
            //_mediator.Send(Mvx.IoCProvider.Resolve(typeof(FragmentBRequest)));
        }
    }
}
