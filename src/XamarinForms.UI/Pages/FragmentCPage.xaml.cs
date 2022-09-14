using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using Xamarin.Forms.Xaml;
using XamarinForms.Core.ViewModels.FragmentC;

namespace XamarinForms.UI.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [MvxContentPagePresentation(WrapInNavigationPage = true)]
    public partial class FragmentCPage : MvxContentPage<FragmentCViewModel>
    {
        public FragmentCPage()
        {
            InitializeComponent();
        }
    }
}
