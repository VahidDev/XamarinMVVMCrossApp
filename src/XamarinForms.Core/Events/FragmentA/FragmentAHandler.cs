using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MvvmCross.Navigation;
using XamarinForms.Core.ViewModels.FragmentA;

namespace XamarinForms.Core.Events.FragmentA
{
    public class FragmentAHandler : IRequestHandler<FragmentARequest>
    {
        private readonly IMvxNavigationService _mvxNavigationService;
        private readonly FragmentAViewModel _fragmentAViewModel;

        public FragmentAHandler(IMvxNavigationService mvxNavigationService, FragmentAViewModel fragmentAViewModel)
        {
            _mvxNavigationService = mvxNavigationService;
            _fragmentAViewModel = fragmentAViewModel;
        }

        public Task<Unit> Handle(FragmentARequest request, CancellationToken cancellationToken)
        {
            _mvxNavigationService.Navigate(_fragmentAViewModel);
            return Unit.Task;
        }
    }
}
