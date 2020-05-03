using Deskberry.UWP.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.WiFi;

namespace Deskberry.UWP.ViewModels.Settings
{
    public class NetworkSettingsPageViewModel
    {
        private IWiFiService _wiFiService;

        public NetworkSettingsPageViewModel()
        {
        }

        public NetworkSettingsPageViewModel(IWiFiService wiFiService)
        {
            _wiFiService = wiFiService;
        }

        //async Task Get()
        //{
        //    var adapters = await WiFiAdapter.FindAllAdaptersAsync();
        //    var networks = adapters[0].NetworkReport.AvailableNetworks;
        //}

        //async Task Connect()
        //{
        //    var adapters = await WiFiAdapter.FindAllAdaptersAsync();
        //    adapters[0].ConnectAsync()
        //}

        //async Task GetStatus()
        //{
        //    var adapters = await WiFiAdapter.FindAllAdaptersAsync();
        //    adapters[0].NetworkAdapter;
        //}
    }
}