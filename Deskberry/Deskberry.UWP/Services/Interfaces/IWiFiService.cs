using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.WiFi;
using Windows.Networking.Connectivity;
using Windows.Security.Credentials;

namespace Deskberry.UWP.Services.Interfaces
{
    public interface IWiFiService
    {
        Task<IEnumerable<WiFiAvailableNetwork>> GetWiFiAvailableNetworksAsync();

        Task<NetworkAdapter> GetNetworkAdapterInformation();

        Task ConnectAsync(WiFiAvailableNetwork selectedNetwork, PasswordCredential passwordCredential);
    }
}