using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Xamarin.Forms;
using Command = Xamarin.Forms.Command;

namespace SampleApp
{
    public class MainViewModel
    {
        public ObservableCollection<MenuOptionModel> OpcionesMenu { get; set; }

        public string MainText { get; set; }

        public MainViewModel()
        {
            OpcionesMenu = new ObservableCollection<MenuOptionModel>();
            var opcion1 = new MenuOptionModel
            {
                Nombre = "Version Xaml",
                Accion = new Command(() => { MessagingCenter.Send(this,"GoTo", new XamlPage()); })
            };
            OpcionesMenu.Add(opcion1);
            var opcion2 = new MenuOptionModel
            {
                Nombre = "Version cs",
                Accion = new Command(() => { Debug.WriteLine("Version cs"); })
            };
            OpcionesMenu.Add(opcion2);
        }

    }

}