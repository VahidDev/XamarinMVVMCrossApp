using System.Collections.Generic;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace XamarinForms.Core.Navigation
{
    internal class Navigation : INavigation
    {
        private int _currentIndex;
        private List<MvxViewModel> _mvxViewModels;

        private readonly IMvxNavigationService _navigationService;

        public bool CanGoBack => _currentIndex > 0;

        public Navigation(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
            _mvxViewModels = new List<MvxViewModel>();
        }

        public void GoBack()
        {
            if (!CanGoBack)
            {
                return;
            }
            _currentIndex --;

            _navigationService.Navigate(_mvxViewModels[_currentIndex]);
        }

        public void Navigate(IMvxViewModel mvxViewModel)
        {
            //_currentIndex++;
            //_mvxViewModels.Add((MvxViewModel) mvxViewModel);

            _navigationService.Navigate(mvxViewModel);
        }
    }
}
