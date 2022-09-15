using MvvmCross.Commands;
using System.Windows.Input;
using MvvmCross;
using XamarinForms.Core.ViewModels.FragmentA;
using XamarinForms.Core.ViewModels.FragmentB;
using XamarinForms.Core.Navigation;
using XamarinForms.Core.ViewModels.FragmentC;
using XamarinForms.Core.Globals;
using MvvmCross.Base;

namespace XamarinForms.Core.ViewModels.FragmentD
{
    public class FragmentDViewModel
        : BaseViewModel
        , IFragmentDViewModel
    {
        private readonly INavigation _navigation;
        private int _counterD;
        private int _sharedCounter;
        private IGlobalModule _globalModule { get; }

        public int CounterD
        {
            get => _counterD;
            set
            {
                _counterD = value;
                RaisePropertyChanged(() => CounterD);
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
        public ICommand GoToBCommand { get; set; }
        public ICommand GoToCCommand { get; set; }
        public ICommand GoToACommand { get; set; }

        public FragmentDViewModel
            ( INavigation navigation
            , IGlobalModule globalModule)
        {
            _navigation = navigation;
            _globalModule = globalModule;

            IncrementCounterCommand = new MvxCommand(IncrementCounter);
            GoToACommand = new MvxCommand(GoToA);
            GoToBCommand = new MvxCommand(GoToB);
            GoToCCommand = new MvxCommand(GoToC);

            _globalModule.GlobalCounterChangedEvent += () => Mvx.IoCProvider
            .Resolve<IMvxMainThreadAsyncDispatcher>()
            .ExecuteOnMainThreadAsync(() => IncrementSharedCounter());
        }

        private void IncrementCounter() => CounterD++;

        private void IncrementSharedCounter() => SharedCounter = _globalModule.Counter;

        private void GoToA()
        {
            _navigation.Navigate(Mvx.IoCProvider.Resolve<IFragmentAViewModel>());
        }

        private void GoToB()
        {
            _navigation.Navigate(Mvx.IoCProvider.Resolve<IFragmentBViewModel>());
        }

        private void GoToC()
        {
            _navigation.Navigate(Mvx.IoCProvider.Resolve<IFragmentCViewModel>());
        }
    }
}
