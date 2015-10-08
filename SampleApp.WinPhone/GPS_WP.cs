using System;
using Windows.Devices.Geolocation;
using SampleApp.WinPhone;

[assembly: Xamarin.Forms.Dependency(typeof(GPSforWP))]
namespace SampleApp.WinPhone
{
    public class GPSforWP:IGPS
    {
        private readonly Geolocator _locator;

        public GPSforWP()
        {
            _locator = new Geolocator();
        }

        public string GetPosition()
        {
            var positionTask = _locator.GetGeopositionAsync().AsTask();
            Geoposition position = null;
            var continuation = positionTask.ContinueWith(t => { position = t.Result; });
            continuation.Wait();
            return position.Coordinate.Longitude.ToString("0.000") + " / " +
                                  position.Coordinate.Latitude.ToString("0.000");
        }
    }
}