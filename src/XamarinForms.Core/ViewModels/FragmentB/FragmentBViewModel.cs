using MvvmCross.Commands;
using System.Windows.Input;
using XamarinForms.Core.Navigation;
using MvvmCross;
using XamarinForms.Core.ViewModels.FragmentA;
using XamarinForms.Core.ViewModels.FragmentD;
using XamarinForms.Core.ViewModels.FragmentC;
using XamarinForms.Core.Globals;

namespace XamarinForms.Core.ViewModels.FragmentB
{
    public class FragmentBViewModel
        : BaseViewModel
        , IFragmentBViewModel
    {
        private int _counterB;
        private readonly INavigation _navigation;

        public int CounterB
        {
            get => _counterB;
            set
            {
                _counterB = value;
                RaisePropertyChanged(() => CounterB);
            }
        }

        public ICommand IncrementCounterCommand { get; set; }
        public ICommand GoToACommand { get; set; }
        public ICommand GoToCCommand { get; set; }
        public ICommand GoToDCommand { get; set; }

        public IGlobalModule Globalmodule { get; }

        public FragmentBViewModel
            ( INavigation navigation
            , IGlobalModule globalModule
            )
        {
            _navigation = navigation;
            Globalmodule = globalModule;

            IncrementCounterCommand = new MvxCommand(IncrementCounter);
            GoToACommand = new MvxCommand(GoToA);
            GoToCCommand = new MvxCommand(GoToC);
            GoToDCommand = new MvxCommand(GoToD);
        }

        private void IncrementCounter() => CounterB++;

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
