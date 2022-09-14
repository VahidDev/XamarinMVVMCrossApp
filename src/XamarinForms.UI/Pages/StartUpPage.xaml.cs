using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using Xamarin.Forms.Xaml;
using XamarinForms.Core.ViewModels.StartUp;

namespace XamarinForms.UI.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [MvxContentPagePresentation(WrapInNavigationPage = true)]
    public partial class StartUpPage : MvxContentPage<StartUpViewModel>
    {
        public StartUpPage()
        {
            InitializeComponent();
        }
    }
}
