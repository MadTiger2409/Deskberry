using Deskberry.UWP.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.WiFi;
using Windows.Networking.Connectivity;
using Windows.Security.Credentials;

namespace Deskberry.UWP.Services
{
    public class WiFiService : IWiFiService
    {
        private WiFiAdapter _adapter;

        public WiFiService(WiFiAdapter adapter)
        {
            _adapter = adapter;
        }

        public async Task ConnectAsync(WiFiAvailableNetwork selectedNetwork, string networkPassword)
        {
            var credentials = new PasswordCredential() { UserName = "deskberry", Password = networkPassword };

            await _adapter.ConnectAsync(selectedNetwork, WiFiReconnectionKind.Automatic, credentials);
        }

        public NetworkAdapter GetNetworkAdapterInformation() => _adapter.NetworkAdapter;

        public async Task<IEnumerable<WiFiAvailableNetwork>> GetWiFiAvailableNetworksAsync()
        {
            await _adapter.ScanAsync();

            return _adapter.NetworkReport.AvailableNetworks;
        }
    }
}