using System.ComponentModel;
using Windows.UI.Xaml.Controls;

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Deskberry.UWP.Dialogs
{
    public sealed partial class ConnectNetworkDialog : ContentDialog, INotifyPropertyChanged
    {
        private string password;

        public string Password
        {
            get => password;
            private set
            {
                if (value == password)
                    return;

                password = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Password)));
            }
        }

        public ConnectNetworkDialog()
        {
            this.InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}