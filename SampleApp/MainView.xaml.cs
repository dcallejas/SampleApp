using Xamarin.Forms;

namespace SampleApp
{
    public partial class MainView : ContentPage
    {
        public MainView()
        {
            InitializeComponent();

            MessagingCenter.Subscribe<MainViewModel,ContentPage>(this, "GoTo", (sender, e) => { Navigation.PushAsync(e); });
        }

        
    }
}
