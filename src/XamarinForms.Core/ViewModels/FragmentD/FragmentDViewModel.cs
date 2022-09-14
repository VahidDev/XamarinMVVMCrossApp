using MvvmCross.Commands;
using System.Windows.Input;
using MvvmCross;
using XamarinForms.Core.ViewModels.FragmentA;
using XamarinForms.Core.ViewModels.FragmentB;
using XamarinForms.Core.Navigation;
using XamarinForms.Core.ViewModels.FragmentC;
using XamarinForms.Core.Globals;

namespace XamarinForms.Core.ViewModels.FragmentD
{
    public class FragmentDViewModel
        : BaseViewModel
        , IFragmentDViewModel
    {
        private readonly INavigation _navigation;
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

        public IGlobalModule Globalmodule { get; }

        public FragmentDViewModel
            ( INavigation navigation
            , IGlobalModule globalModule)
        {
            _navigation = navigation;
            Globalmodule = globalModule;

            IncrementCounterCommand = new MvxCommand(IncrementCounter);
            GoToACommand = new MvxCommand(GoToA);
            GoToBCommand = new MvxCommand(GoToB);
            GoToCCommand = new MvxCommand(GoToC);
        }

        private void IncrementCounter() => CounterD++;

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
