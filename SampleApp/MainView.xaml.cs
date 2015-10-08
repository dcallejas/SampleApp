using Xamarin.Forms;

namespace SampleApp
{
    public partial class MainView : ContentPage
    {
        public MainView()
        {
            InitializeComponent();

            MessagingCenter.Subscribe<MainViewModel,string>(this, "GoTo", (sender, e) =>
            {
                ContentPage page = null;
                switch (e)
                {
                    case "CS":
                        page = new CSPage();
                        break;
                    case "XAML":
                        page = new XamlPage();
                        break;
                }
                if (page != null) this.Navigation.PushAsync(page);
            });
        }

        
    }
}
