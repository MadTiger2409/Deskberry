using Deskberry.UWP.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.WiFi;

namespace Deskberry.UWP.ViewModels.Settings
{
    public class NetworkSettingsPageViewModel : INotifyPropertyChanged
    {
        private IWiFiService _wiFiService;

        private string _password;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<WiFiAvailableNetwork> AvailableNetworks { get; set; }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public async Task InitializeDataAsync()
        {
            AvailableNetworks = new ObservableCollection<WiFiAvailableNetwork>(await _wiFiService.GetWiFiAvailableNetworksAsync());
            PropertyChanged?.Invoke(AvailableNetworks, new PropertyChangedEventArgs(nameof(AvailableNetworks)));
        }

        public NetworkSettingsPageViewModel()
        {
            AvailableNetworks = new ObservableCollection<WiFiAvailableNetwork>();
        }

        public NetworkSettingsPageViewModel(IWiFiService wiFiService) : this()
        {
            _wiFiService = wiFiService;
        }
    }
}