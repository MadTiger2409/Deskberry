using Deskberry.Helpers.Commands;
using Deskberry.Tools.Enums;
using Deskberry.UWP.Dialogs;
using Deskberry.UWP.Helpers;
using Deskberry.UWP.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.WiFi;
using Windows.UI.Xaml.Controls;

namespace Deskberry.UWP.ViewModels.Settings
{
    public class NetworkSettingsPageViewModel
    {
        private IWiFiService _wiFiService;
        private WiFiAvailableNetwork _selectedNetwork;
        private string _currentNetworkName;

        public event PropertyChangedEventHandler PropertyChanged;

        public RelayCommand RefreshCommand { get; protected set; }
        public RelayCommand ConnectCommand { get; protected set; }

        public WiFiAvailableNetwork SelectedNetwork
        {
            get => _selectedNetwork;
            set
            {
                if (value == _selectedNetwork)
                    return;

                _selectedNetwork = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedNetwork)));
            }
        }

        public string CurrentNetworkName
        {
            get => _currentNetworkName;
            set
            {
                _currentNetworkName = string.IsNullOrEmpty(value) ? "None" : value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentNetworkName)));
            }
        }

        public ObservableCollection<WiFiAvailableNetwork> AvailableNetworks { get; set; }

        public async Task InitializeDataAsync()
        {
            await RefreshAvailableNetworks();
            CurrentNetworkName = await _wiFiService.GetCurrentNetworkNameAsync();
        }

        public NetworkSettingsPageViewModel()
        {
            AvailableNetworks = new ObservableCollection<WiFiAvailableNetwork>();
        }

        public NetworkSettingsPageViewModel(IWiFiService wiFiService) : this()
        {
            _wiFiService = wiFiService;
            InitializeCommands();
        }

        private async Task RefreshAvailableNetworks()
        {
            var networks = await _wiFiService.GetWiFiAvailableNetworksAsync();
            UpdateNetworksCollection(networks);
        }

        private void UpdateNetworksCollection(IEnumerable<WiFiAvailableNetwork> networks)
        {
            AvailableNetworks.Clear();

            foreach (var network in networks)
            {
                AvailableNetworks.Add(network);
            }
        }

        private async Task ConnectToWiFiAsync()
        {
            var password = string.Empty;

            var dialog = DialogHelper.GetContentDialog(DialogEnum.ConnectNetworkDialog);
            var resoult = await dialog.ShowAsync();

            if (resoult == ContentDialogResult.Primary)
            {
                password = (dialog as ConnectNetworkDialog).Password;
                await ConnectToSelecctedWiFiNetworkAsync(SelectedNetwork, password);
                CurrentNetworkName = await _wiFiService.GetCurrentNetworkNameAsync();
            }
        }

        private async Task ConnectToSelecctedWiFiNetworkAsync(WiFiAvailableNetwork selectedNetwork, string password)
        {
            var status = await _wiFiService.ConnectAsync(selectedNetwork, password);

            var dialog = DialogHelper.GetContentDialog(DialogEnum.StandardDialog, status);
            await dialog.ShowAsync();
        }

        private void InitializeCommands()
        {
            RefreshCommand = new RelayCommand(async () => await RefreshAvailableNetworks());
            ConnectCommand = new RelayCommand(async () => await ConnectToWiFiAsync());
        }
    }
}