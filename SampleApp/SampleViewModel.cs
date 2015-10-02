using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.ServiceModel.Channels;
using System.Threading.Tasks;
using SampleApp.Annotations;
using Xamarin.Forms;

namespace SampleApp
{
    public class SampleViewModel:INotifyPropertyChanged
    {
        private int _red;
        private int _green;
        private int _blue;
        public string MainText { get; set; }

        public int Red
        {
            get { return _red; }
            set { _red = value; OnPropertyChanged("LabelsColor"); } 
        }

        public int Green
        {
            get { return _green; }
            set { _green = value; OnPropertyChanged("LabelsColor"); }
        }
        public int Blue
        {
            get { return _blue; }
            set { _blue = value; OnPropertyChanged("LabelsColor"); }
        }

        public Color LabelsColor
        {
            get { return Color.FromRgb(Red, Green, Blue); } 
        }

        public ObservableCollection<Posicion> TextosCollection { get; set; }

        public SampleViewModel ()
        {
            MainText = "Añadir objetos y dependencia";
            Blue = 255;
            TextosCollection = new ObservableCollection<Posicion>();
            TextosCollection.Add(new Posicion() { AsTexto = DateTime.Now.ToString("T") + " @ " + DependencyService.Get<IGPS>().GetPosition() });
            AddPosition();
        }

        private async void AddPosition()
        {
            while (true)
            {
                TextosCollection.Add(new Posicion() { AsTexto = DateTime.Now.ToString("T") + " @ " + DependencyService.Get<IGPS>().GetPosition()});
                await Task.Delay(50000);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class Posicion
    {
        public string AsTexto { get; set; }
    }
}