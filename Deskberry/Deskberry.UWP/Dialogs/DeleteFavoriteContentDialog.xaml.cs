using Windows.UI.Xaml.Controls;

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Deskberry.UWP.Dialogs
{
    public sealed partial class DeleteFavoriteContentDialog : ContentDialog
    {
        public DeleteFavoriteContentDialog()
        {
            this.InitializeComponent();
            contentTextBlock.Text = $"Are you sure you want to delete {(string)DataContext}?";
        }
    }
}