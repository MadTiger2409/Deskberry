using Deskberry.UWP.IoC;
using Deskberry.UWP.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Deskberry.UWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NotesPage : Page
    {
        public Frame NavigationFrame
        {
            get { return ContentFrame; }
            set { ContentFrame = value; }
        }

        public NotesPage()
        {
            this.InitializeComponent();
            DataContext = MainContainer.Container.GetService<NotesViewModel>();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var viewModel = DataContext as NotesViewModel;
            viewModel.SetMenuItemOnStart();
        }
    }
}
