using MvvmCross.ViewModels;

namespace XamarinForms.Core.Navigation
{
    public interface INavigation
    {
        bool CanGoBack { get; }
        void GoBack();
        void Navigate(IMvxViewModel mvxViewModel);
        void NavigateToB(IMvxViewModel mvxViewModel);
        void NavigateToA(IMvxViewModel mvxViewModel);
    }
}
