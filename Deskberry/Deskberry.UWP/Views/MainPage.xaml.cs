using Deskberry.UWP.IoC;
using Deskberry.UWP.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Deskberry.UWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            DataContext = MainContainer.Container.GetService<MainPageViewModel>();
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);

            passwordBox.Password = "";
            passwordBox.PlaceholderText = "Password";
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            try
            {
                base.OnNavigatedTo(e);

                var vm = DataContext as MainPageViewModel;
                vm.RefreshAccounts();
            }
            catch (System.Exception ex)
            {
                var meessage = ex.Message;
            }
        }
    }
}