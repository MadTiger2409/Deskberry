using Deskberry.UWP.IoC;
using Deskberry.UWP.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Deskberry.UWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BrowserPage : Page
    {
        public BrowserPage()
        {
            this.InitializeComponent();
            DataContext = MainContainer.Container.GetService<BrowserViewModel>();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            var viewModel = DataContext as BrowserViewModel;
            await viewModel.InitializeDataAsync();
        }

        // A workaround for accessing parent's command
        private void Button_Click_DeleteFavorite(object sender, RoutedEventArgs e)
        {
            var viewModel = (BrowserViewModel)DataContext;
            var button = (Button)sender;

            if (viewModel.DeleteFavoriteCommand.CanExecute(button.Tag))
                viewModel.DeleteFavoriteCommand.Execute(button.Tag);

            FavoritesListView.ItemsSource = viewModel.Favorites;
        }

        private void Button_Click_LoadFavorite(object sender, RoutedEventArgs e)
        {
            var viewModel = (BrowserViewModel)DataContext;
            var button = (Button)sender;

            if (viewModel.LoadFavoriteCommand.CanExecute(button.Tag))
                viewModel.LoadFavoriteCommand.Execute(button.Tag);
        }
    }
}