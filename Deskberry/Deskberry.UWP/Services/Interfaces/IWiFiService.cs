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

        Task<string> GetCurrentNetworkNameAsync();

        /// <summary>
        /// Connect to the selected Wi-Fi network using provided password
        /// </summary>
        /// <param name="selectedNetwork">The network you want to connect to</param>
        /// <param name="networkPassword">The network password required to establish the connection</param>
        /// <returns>The status of the attempt to connect to the Wi-Fi network</returns>
        Task<string> ConnectAsync(WiFiAvailableNetwork selectedNetwork, string networkPassword);
    }
}