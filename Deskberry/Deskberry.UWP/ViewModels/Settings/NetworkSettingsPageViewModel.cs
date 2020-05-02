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
    }
}