using MvvmCross.Commands;
using System.Windows.Input;
using XamarinForms.Core.Navigation;
using MvvmCross;
using XamarinForms.Core.ViewModels.FragmentA;
using XamarinForms.Core.ViewModels.FragmentD;
using XamarinForms.Core.ViewModels.FragmentC;
using XamarinForms.Core.Globals;
using MvvmCross.Base;

namespace XamarinForms.Core.ViewModels.FragmentB
{
    public class FragmentBViewModel
        : BaseViewModel
        , IFragmentBViewModel
    {
        private int _counterB;
        private int _sharedCounter;
        private readonly INavigation _navigation;
        private IGlobalModule _globalModule { get; }

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
        public ICommand GoToACommand { get; set; }
        public ICommand GoToCCommand { get; set; }
        public ICommand GoToDCommand { get; set; }

        public FragmentBViewModel
            (INavigation navigation
            , IGlobalModule globalModule
            )
        {
            _navigation = navigation;
            _globalModule = globalModule;

            IncrementCounterCommand = new MvxCommand(IncrementCounter);
            GoToACommand = new MvxCommand(GoToA);
            GoToCCommand = new MvxCommand(GoToC);
            GoToDCommand = new MvxCommand(GoToD);

            _globalModule.GlobalCounterChangedEvent += () => Mvx.IoCProvider
            .Resolve<IMvxMainThreadAsyncDispatcher>()
            .ExecuteOnMainThreadAsync(() => IncrementSharedCounter());
        }

        private void IncrementCounter() => CounterB++;

        private void IncrementSharedCounter() => SharedCounter = _globalModule.Counter;

        private void GoToA()
        {
            _navigation.Navigate(Mvx.IoCProvider.Resolve<IFragmentAViewModel>());
        }

        private void GoToC()
        {
            _navigation.Navigate(Mvx.IoCProvider.Resolve<IFragmentCViewModel>());
        }


        private void GoToD()
        {
            _navigation.Navigate(Mvx.IoCProvider.Resolve<IFragmentDViewModel>());
        }
    }
}
