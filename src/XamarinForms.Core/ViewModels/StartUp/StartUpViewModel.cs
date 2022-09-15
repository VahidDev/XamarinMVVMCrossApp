using MvvmCross.Commands;
using MvvmCross;
using System.Windows.Input;
using XamarinForms.Core.Navigation;
using XamarinForms.Core.ViewModels.FragmentA;
using XamarinForms.Core.Globals;

namespace XamarinForms.Core.ViewModels.StartUp
{
    public class StartUpViewModel
        : BaseViewModel
        , IStartUpPageViewModel
    {
        private readonly INavigation _navigation;
        private readonly IGlobalModule _globalModule;

        public ICommand StartCommand { get; set; }

        public StartUpViewModel
            ( INavigation navigation
            , IGlobalModule globalModule
            )
        {
            _navigation = navigation;
            _globalModule = globalModule;
            StartCommand = new MvxCommand(GoToA);
        }

        private void GoToA()
        {
            _globalModule.StartBackgroundTimer();
            _navigation.Navigate(Mvx.IoCProvider.Resolve<IFragmentAViewModel>());
        }
    }
}
