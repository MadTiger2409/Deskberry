using Deskberry.UWP.IoC;
using Deskberry.UWP.ViewModels.Notes;
using Microsoft.Extensions.DependencyInjection;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Deskberry.UWP.Views.Notes
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddNotePage : Page
    {
        public AddNotePage()
        {
            this.InitializeComponent();
            DataContext = MainContainer.Container.GetService<AddNotePageViewModel>();
        }
    }
}
