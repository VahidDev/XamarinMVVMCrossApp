using MvvmCross.ViewModels;

namespace XamarinForms.Core.Navigation
{
    public interface INavigation
    {
        bool CanGoBack { get; }
        void GoBack();
        void Navigate(IMvxViewModel mvxViewModel);
    }
}
