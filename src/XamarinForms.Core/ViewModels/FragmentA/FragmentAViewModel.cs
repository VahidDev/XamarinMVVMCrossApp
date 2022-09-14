using MvvmCross.Commands;
using System.Windows.Input;
using MvvmCross;
using XamarinForms.Core.ViewModels.FragmentB;
using XamarinForms.Core.Navigation;
using XamarinForms.Core.ViewModels.FragmentD;
using XamarinForms.Core.ViewModels.FragmentC;
using XamarinForms.Core.Globals;

namespace XamarinForms.Core.ViewModels.FragmentA
{
    public class FragmentAViewModel
        : BaseViewModel
        , IFragmentAViewModel
    {

        private readonly INavigation _navigation;
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

        public ICommand IncrementCounterCommand { get; set; }
        public ICommand GoToBCommand { get; set; }
        public ICommand GoToCCommand { get; set; }
        public ICommand GoToDCommand { get; set; }

        public IGlobalModule Globalmodule { get; }

        public FragmentAViewModel
            ( INavigation navigation
            , IGlobalModule globalModule
            )
        {
            _navigation = navigation;
            Globalmodule = globalModule;

            IncrementCounterCommand = new MvxCommand(IncrementCounter);
            GoToBCommand = new MvxCommand(GoToB);
            GoToCCommand = new MvxCommand(GoToC);
            GoToDCommand = new MvxCommand(GoToD);
        }

        private void IncrementCounter() => CounterA++;

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
