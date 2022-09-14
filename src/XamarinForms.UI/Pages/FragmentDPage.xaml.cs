using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using Xamarin.Forms.Xaml;
using XamarinForms.Core.ViewModels.FragmentD;

namespace XamarinForms.UI.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [MvxContentPagePresentation(WrapInNavigationPage = true)]
    public partial class FragmentDPage : MvxContentPage<FragmentDViewModel>
    {
        public FragmentDPage()
        {
            InitializeComponent();
        }
    }
}
