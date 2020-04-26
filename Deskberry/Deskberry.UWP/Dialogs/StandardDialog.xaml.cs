using Windows.UI.Xaml.Controls;

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Deskberry.UWP.Dialogs
{
    public sealed partial class StandardDialog : ContentDialog
    {
        public StandardDialog()
        {
            this.InitializeComponent();
        }

        public StandardDialog(string content) : this()
        {
            contentTextBlock.Text = content;
        }
    }
}