using Deskberry.UWP.Commands;
using System.ComponentModel;
using Windows.UI.Xaml.Controls;

namespace Deskberry.UWP.ViewModels
{
    public class BrowserViewModel : INotifyPropertyChanged
    {
        public BrowserViewModel()
        {
            WebView = new WebView();

            GoBackwardCommand = new RelayCommand(() => WebView.GoBack(), CanGoBackward);
            GoForwardCommand = new RelayCommand(() => WebView.GoForward(), CanGoForward);
            RefreshCommand = new RelayCommand(() => WebView.Refresh());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public RelayCommand GoBackwardCommand { get; private set; }
        public RelayCommand GoForwardCommand { get; private set; }
        public RelayCommand GoHomeCommand { get; private set; }
        public RelayCommand RefreshCommand { get; private set; }

        public WebView WebView { get; set; }

        private bool CanGoBackward() => WebView.CanGoBack;

        private bool CanGoForward() => WebView.CanGoForward;
    }
}