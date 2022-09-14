using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MvvmCross.Navigation;
using XamarinForms.Core.ViewModels.FragmentA;
using XamarinForms.Core.ViewModels.FragmentB;

namespace XamarinForms.Core.Events.FragmentB
{
    public class FragmentBHandler : IRequestHandler<FragmentBRequest>
    {
        private readonly IMvxNavigationService _mvxNavigationService;
        private readonly FragmentBViewModel _fragmentBViewModel;

        public FragmentBHandler(IMvxNavigationService mvxNavigationService, FragmentBViewModel fragmentBViewModel)
        {
            _mvxNavigationService = mvxNavigationService;
            _fragmentBViewModel = fragmentBViewModel;
        }

        public Task<Unit> Handle(FragmentBRequest request, CancellationToken cancellationToken)
        {
            _mvxNavigationService.Navigate(_fragmentBViewModel);
            return Unit.Task;
        }
    }
}
