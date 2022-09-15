using MvvmCross.Commands;
using System.Windows.Input;
using XamarinForms.Core.Navigation;
using MvvmCross;
using XamarinForms.Core.ViewModels.FragmentD;
using XamarinForms.Core.ViewModels.FragmentA;
using XamarinForms.Core.ViewModels.FragmentB;
using XamarinForms.Core.Globals;
using MvvmCross.Base;

namespace XamarinForms.Core.ViewModels.FragmentC
{
    public class FragmentCViewModel
        : BaseViewModel
        , IFragmentCViewModel
    {
        private int _counterC;
        private readonly INavigation _navigation;
        private int _sharedCounter;
        private IGlobalModule _globalModule { get; }

        public int CounterC
        {
            get => _counterC;
            set
            {
                _counterC = value;
                RaisePropertyChanged(() => CounterC);
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
        public ICommand GoToBCommand { get; set; }
        public ICommand GoToDCommand { get; set; }

        public FragmentCViewModel
            ( INavigation navigation
            , IGlobalModule globalModule
            )
        {
            _navigation = navigation;
            _globalModule = globalModule;

            IncrementCounterCommand = new MvxCommand(IncrementCounter);
            GoToACommand = new MvxCommand(GoToA);
            GoToBCommand = new MvxCommand(GoToB);
            GoToDCommand = new MvxCommand(GoToD);

            _globalModule.GlobalCounterChangedEvent += () => Mvx.IoCProvider
            .Resolve<IMvxMainThreadAsyncDispatcher>()
            .ExecuteOnMainThreadAsync(() => IncrementSharedCounter());
        }

        private void IncrementCounter() => CounterC++;

        private void IncrementSharedCounter() => SharedCounter = _globalModule.Counter;

        private void GoToA()
        {
            _navigation.Navigate(Mvx.IoCProvider.Resolve<IFragmentAViewModel>());
        }

        private void GoToB()
        {
            _navigation.Navigate(Mvx.IoCProvider.Resolve<IFragmentBViewModel>());
        }

        private void GoToD()
        {
            _navigation.Navigate(Mvx.IoCProvider.Resolve<IFragmentDViewModel>());
        }


    }
}
