using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.ViewModels;
using XamarinForms.Core.Globals;
using XamarinForms.Core.Navigation;
using XamarinForms.Core.ViewModels.FragmentA;
using XamarinForms.Core.ViewModels.FragmentB;
using XamarinForms.Core.ViewModels.FragmentC;
using XamarinForms.Core.ViewModels.FragmentD;
using XamarinForms.Core.ViewModels.StartUp;

namespace XamarinForms.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            RegisterAppStart<StartUpViewModel>();

            Mvx.IoCProvider.ConstructAndRegisterSingleton<IGlobalModule,GlobalModule>();

            Mvx.IoCProvider.ConstructAndRegisterSingleton<INavigation, XamarinForms.Core.Navigation.Navigation>();
            Mvx.IoCProvider.ConstructAndRegisterSingleton<IFragmentAViewModel, FragmentAViewModel>();
            Mvx.IoCProvider.ConstructAndRegisterSingleton<IFragmentBViewModel, FragmentBViewModel>();
            Mvx.IoCProvider.ConstructAndRegisterSingleton<IFragmentCViewModel, FragmentCViewModel>();
            Mvx.IoCProvider.ConstructAndRegisterSingleton<IFragmentDViewModel, FragmentDViewModel>();
        }
    }
}
