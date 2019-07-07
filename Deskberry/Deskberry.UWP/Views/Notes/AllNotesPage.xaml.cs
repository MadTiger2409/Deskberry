using Deskberry.UWP.IoC;
using Deskberry.UWP.ViewModels.Notes;
using Microsoft.Extensions.DependencyInjection;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Deskberry.UWP.Views.Notes
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AllNotesPage : Page
    {
        public AllNotesPage()
        {
            this.InitializeComponent();
            DataContext = MainContainer.Container.GetService<AllNotesPageViewModel>();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var viewModel = DataContext as AllNotesPageViewModel;
            viewModel.RefreshNotesCollection();
        }

        // A workaround for accessing parent's command
        private void Button_Click_DeleteNote(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var viewModel = (AllNotesPageViewModel)DataContext;
            var button = (Button)sender;

            if (viewModel.DeleteCommand.CanExecute(button.Tag))
                viewModel.DeleteCommand.Execute(button.Tag);

            NotesListView.ItemsSource = viewModel.Notes;
        }
    }
}
