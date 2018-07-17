using ADDC_MVVM.ViewModels;
using Xamarin.Forms;

namespace ADDC_MVVM.Views
{
    public partial class OAEmiratesEntry : ContentPage
    {
       
        public OAEmiratesEntry()
        {
            InitializeComponent();
            var nav = new NavigationPage(new ContentPage { Title = "Page" });
            nav.BarBackgroundColor = Color.Blue;
        }
        public EmiratesIdEntryViewModel ViewModel { get { return (BindingContext as EmiratesIdEntryViewModel); } }

        // private void submitEmiratesID(Object obj, EventArgs evargs) { }

    }
}
