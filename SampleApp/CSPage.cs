
using System.Xml;
using Xamarin.Forms;

namespace SampleApp
{
    // ReSharper disable once InconsistentNaming
    public class CSPage : ContentPage
    {
        public CSPage()
        {
            BindingContext = new SampleViewModel();
            var lblMainText = new Label();
            lblMainText.SetBinding(Label.TextProperty, new Binding("MainText"));
            lblMainText.SetBinding(Label.TextColorProperty, new Binding("LabelsColor"));
            var lblRed = new Label
            {
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof (Label)),
                VerticalOptions = LayoutOptions.Start,
                Text = "Red:"
            };
            var lblGreen = new Label
            {
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                VerticalOptions = LayoutOptions.Start,
                Text = "Green:"
            };
            var lblBlue = new Label
            {
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                VerticalOptions = LayoutOptions.Start,
                Text = "Blue:"
            };
            var sliderRed = new Slider
            {
                Minimum = 0,
                Maximum = 255,
                BackgroundColor = Color.Gray,
                HorizontalOptions = LayoutOptions.Fill,
                HeightRequest = 80,
                VerticalOptions = LayoutOptions.Start
            };
            sliderRed.SetBinding(Slider.ValueProperty,new Binding("Red",BindingMode.TwoWay));

            var sliderGreen = new Slider
            {
                Minimum = 0,
                Maximum = 255,
                BackgroundColor = Color.Gray,
                HorizontalOptions = LayoutOptions.Fill,
                HeightRequest = 80,
                VerticalOptions = LayoutOptions.Start
            };
            sliderGreen.SetBinding(Slider.ValueProperty, new Binding("Green", BindingMode.TwoWay));

            var sliderBlue = new Slider
            {
                Minimum = 0,
                Maximum = 255,
                BackgroundColor = Color.Gray,
                HorizontalOptions = LayoutOptions.Fill,
                HeightRequest = 80,
                VerticalOptions = LayoutOptions.Start
            };
            sliderBlue.SetBinding(Slider.ValueProperty, new Binding("Blue", BindingMode.TwoWay));

            var listado = new ListView();
            listado.SetBinding(ListView.ItemsSourceProperty,"TextosCollection");
            listado.ItemTemplate = new DataTemplate(typeof(TextCell));
            listado.ItemTemplate.SetBinding(TextCell.TextProperty,"AsTexto");
            listado.ItemTemplate.SetBinding(TextCell.TextColorProperty, "ColorTexto");

            Content = new StackLayout
            {
                Children = {
					lblMainText,lblRed,sliderRed,lblGreen,sliderGreen,lblBlue,sliderBlue,new ScrollView(){Content = listado}
				}
            };
        }
    }
}
