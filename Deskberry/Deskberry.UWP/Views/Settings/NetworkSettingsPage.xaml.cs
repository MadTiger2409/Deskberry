using Windows.UI.Xaml.Controls;
using Microsoft.Extensions.DependencyInjection;
using Windows.UI.Xaml.Navigation;
using Deskberry.UWP.IoC;
using Deskberry.UWP.ViewModels.Settings;

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
            base.OnNavigatedTo(e);

            var vm = DataContext as NetworkSettingsPageViewModel;
            await vm.InitializeDataAsync();
        }
    }
}