﻿using Deskberry.Helpers.Commands;
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

        public ObservableCollection<WiFiAvailableNetwork> AvailableNetworks { get; set; }

        public async Task InitializeDataAsync()
        {
            await RefreshAvailableNetworks();
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
                await _wiFiService.ConnectAsync(SelectedNetwork, password);
            }
        }

        private void InitializeCommands()
        {
            RefreshCommand = new RelayCommand(async () => await RefreshAvailableNetworks());
            ConnectCommand = new RelayCommand(async () => await ConnectToWiFiAsync());
        }
    }
}