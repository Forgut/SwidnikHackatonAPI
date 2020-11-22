using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace SwidnikHackaton.AndroidApp
{
    [Service]
    public class GeolocationService : Service
    {
        private Guid _guid = Guid.NewGuid();
        private Location _lastLocation;
        private DateTime _lastLocationTime = DateTime.Now;
        private string _url = "https://swidnikhackatonapi.azurewebsites.net/PedestriansTraffic/Insert";
        public override IBinder OnBind(Intent intent)
        {
            return null;
        }
        public override StartCommandResult OnStartCommand(Intent intent, StartCommandFlags flags, int startId)
        {
            new Timer((o) => GetCurrentLocation(), null, 0, 5000);
            return StartCommandResult.NotSticky;
        }
        public override bool StopService(Intent name)
        {
            return base.StopService(name);
        }

        private async Task GetCurrentLocation()
        {
            try
            {
                Log.Debug("LOG", "Getting location");
                var location = await Geolocation.GetLocationAsync();
                if (location != null)
                {
                    if (_lastLocation != null && location.Latitude == _lastLocation.Latitude && location.Longitude == _lastLocation.Longitude)
                        return;
                    if (_lastLocation != null && (DateTime.Now - _lastLocationTime).TotalMinutes >= 10)
                        _guid = Guid.NewGuid();
                    _lastLocation = location;
                    _lastLocationTime = DateTime.Now;
                    var result = await new HttpClient().PostAsync(_url + $"/?guid={_guid}&latitude={location.Latitude}&longitude={location.Longitude}", null);
                    Log.Debug("result", result.StatusCode.ToString());
                }
                else
                    Log.Debug("LOG", "location is null");
            }
            catch (Exception ex)
            {

            }
        }
    }
}