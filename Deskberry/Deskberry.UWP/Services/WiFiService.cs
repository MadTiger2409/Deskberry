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

        public Task ConnectAsync(WiFiAvailableNetwork selectedNetwork, PasswordCredential passwordCredential) => throw new NotImplementedException();

        public Task<NetworkAdapter> GetNetworkAdapterInformation() => throw new NotImplementedException();

        public async Task<IEnumerable<WiFiAvailableNetwork>> GetWiFiAvailableNetworksAsync()
        {
            var scan = _adapter.ScanAsync();
            await scan;

            Task.WaitAll(scan.AsTask());
            return _adapter.NetworkReport.AvailableNetworks;
        }
    }
}