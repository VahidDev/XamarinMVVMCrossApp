using System;
using MediatR;
using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.ViewModels;
using XamarinForms.Core.Events.FragmentA;
using XamarinForms.Core.Navigation;
using XamarinForms.Core.ViewModels.FragmentA;
using XamarinForms.Core.ViewModels.FragmentB;
using XamarinForms.Core.ViewModels.FragmentC;
using XamarinForms.Core.ViewModels.FragmentD;

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

            Mvx.IoCProvider.ConstructAndRegisterSingleton<IGlobalModule,GlobalModule>();
            RegisterAppStart<FragmentAViewModel>();

            //Mvx.IoCProvider.LazyConstructAndRegisterSingleton<IMediator, Mediator>();
            //Mvx.IoCProvider.ConstructAndRegisterSingleton(typeof(FragmentARequest));
            //Mvx.IoCProvider.ConstructAndRegisterSingleton(typeof(FragmentAHandler));

            //Mvx.IoCProvider.RegisterSingleton<ServiceFactory>((Type serviceType) =>
            //{
            //    IMvxIoCProvider resolver = Mvx.IoCProvider.Resolve<IMvxIoCProvider>();

            //    try
            //    {
            //        return resolver.Resolve(serviceType);
            //    }
            //    catch (Exception)
            //    {
            //        // a "bit" buggy, I know!
            //        return Array.CreateInstance(serviceType.GenericTypeArguments[0], 0);
            //    }
            //});

            Mvx.IoCProvider.ConstructAndRegisterSingleton<INavigation, XamarinForms.Core.Navigation.Navigation>();
            Mvx.IoCProvider.ConstructAndRegisterSingleton(typeof(FragmentAViewModel));
            Mvx.IoCProvider.ConstructAndRegisterSingleton(typeof(FragmentBViewModel));
            Mvx.IoCProvider.ConstructAndRegisterSingleton(typeof(FragmentCViewModel));
            Mvx.IoCProvider.ConstructAndRegisterSingleton(typeof(FragmentDViewModel));
        }
    }
}
