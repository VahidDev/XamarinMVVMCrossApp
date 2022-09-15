 using MvvmCross.Commands;
using System.Windows.Input;
using MvvmCross;
using XamarinForms.Core.ViewModels.FragmentB;
using XamarinForms.Core.Navigation;
using XamarinForms.Core.ViewModels.FragmentD;
using XamarinForms.Core.ViewModels.FragmentC;
using XamarinForms.Core.Globals;
using MvvmCross.Base;

namespace XamarinForms.Core.ViewModels.FragmentA
{
    public class FragmentAViewModel
        : BaseViewModel
        , IFragmentAViewModel
    {

        private readonly INavigation _navigation;
        private int _counterA;
        private int _sharedCounter;
        private IGlobalModule _globalModule { get; }

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
        public ICommand GoToBCommand { get; set; }
        public ICommand GoToCCommand { get; set; }
        public ICommand GoToDCommand { get; set; }


        public FragmentAViewModel
            ( INavigation navigation
            , IGlobalModule globalModule
            )
        {
            _navigation = navigation;
            _globalModule = globalModule;

            IncrementCounterCommand = new MvxCommand(IncrementCounter);
            GoToBCommand = new MvxCommand(GoToB);
            GoToCCommand = new MvxCommand(GoToC);
            GoToDCommand = new MvxCommand(GoToD);
             
            _globalModule.GlobalCounterChangedEvent += () => Mvx.IoCProvider
            .Resolve<IMvxMainThreadAsyncDispatcher>()
            .ExecuteOnMainThreadAsync(()=> IncrementSharedCounter());
        }

        private void IncrementCounter() => CounterA++;

        private void IncrementSharedCounter() => SharedCounter =_globalModule.Counter;

        private void GoToB()
        {
            _navigation.Navigate(Mvx.IoCProvider.Resolve<IFragmentBViewModel>());
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
