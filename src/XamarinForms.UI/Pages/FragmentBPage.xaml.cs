using Xamarin.Forms.Xaml;
using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using XamarinForms.Core.ViewModels.FragmentB;

namespace XamarinForms.UI.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [MvxContentPagePresentation(WrapInNavigationPage = true)]
    public partial class FragmentBPage : MvxContentPage<FragmentBViewModel>
    {
        public FragmentBPage()
        {
            InitializeComponent();
        }
    }
}
