using Windows.UI.Xaml.Controls;
using Microsoft.Extensions.DependencyInjection;
using Windows.UI.Xaml.Navigation;
using Deskberry.UWP.IoC;
using Deskberry.UWP.ViewModels.Settings;
using Windows.UI.Xaml;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Deskberry.UWP.Views.Settings
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NetworkSettingsPage : Page
    {
        public NetworkSettingsPage()
        {
            this.InitializeComponent();

            var vm = MainContainer.Container.GetService<NetworkSettingsPageViewModel>();
            DataContext = vm;
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            var vm = DataContext as NetworkSettingsPageViewModel;
            await vm.InitializeDataAsync();

            // Sometimes OnNavigatedTo isn't working as designed so this line exists
            currentNetworkNameContentPresenter.Content = vm.CurrentNetworkName;
        }

        private async void ConnectButtonClicked(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as NetworkSettingsPageViewModel;

            await vm.ConnectToWiFiAsync();
            currentNetworkNameContentPresenter.Content = vm.CurrentNetworkName;
        }
    }
}