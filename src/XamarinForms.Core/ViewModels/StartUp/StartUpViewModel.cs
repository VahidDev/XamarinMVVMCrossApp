using MvvmCross.Commands;
using MvvmCross;
using System.Windows.Input;
using XamarinForms.Core.Navigation;
using XamarinForms.Core.ViewModels.FragmentA;

namespace XamarinForms.Core.ViewModels.StartUp
{
    public class StartUpViewModel
        : BaseViewModel
        , IStartUpPageViewModel
    {
        private readonly INavigation _navigation;

        public ICommand StartCommand { get; set; }

        public StartUpViewModel(INavigation navigation)
        {
            _navigation = navigation;

            StartCommand = new MvxCommand(GoToA);
        }

        private void GoToA()
        {
            _navigation.Navigate(Mvx.IoCProvider.Resolve<IFragmentAViewModel>());
        }
    }
}
