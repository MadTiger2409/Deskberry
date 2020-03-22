using Deskberry.UWP.IoC;
using Deskberry.UWP.ViewModels.Settings;
using Microsoft.Extensions.DependencyInjection;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Deskberry.UWP.Views.Settings
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BrowserSettingsPage : Page
    {
        public BrowserSettingsPage()
        {
            this.InitializeComponent();
            DataContext = MainContainer.Container.GetService<BrowserSettingsPageViewModel>();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            var vm = DataContext as BrowserSettingsPageViewModel;
            await vm.InitializeDataAsync();

            base.OnNavigatedTo(e);
        }
    }
}