using Deskberry.SQLite.Models;
using Deskberry.Tools.Enums;
using Deskberry.Tools.Extensions;
using Deskberry.Tools.Services.Interfaces;
using Deskberry.UWP.Commands;
using Deskberry.UWP.Commands.Generic;
using Deskberry.UWP.Helpers;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace Deskberry.UWP.ViewModels
{
    public class BrowserViewModel : INotifyPropertyChanged
    {
        private readonly IFavoriteService _favoriteService;

        private string uri;

        public BrowserViewModel()
        {
        }

        public BrowserViewModel(IFavoriteService favoriteService)
        {
            _favoriteService = favoriteService;
            Favorites = new ObservableCollection<Favorite>();
            InitializeWebView();
            InitializeCommands();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public RelayCommand AddFavoriteCommand { get; protected set; }
        public RelayCommand<object> DeleteFavoriteCommand { get; protected set; }
        public ObservableCollection<Favorite> Favorites { get; set; }
        public RelayCommand GoBackwardCommand { get; protected set; }
        public RelayCommand GoForwardCommand { get; protected set; }
        public RelayCommand GoHomeCommand { get; protected set; }
        public RelayCommand GoToCommand { get; protected set; }
        public RelayCommand RefreshCommand { get; protected set; }

        public string Uri
        {
            get { return uri; }
            set
            {
                uri = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Uri)));
            }
        }

        public WebView WebView { get; set; }

        public void RefreshFavoritesCollection()
        {
            var favorites = _favoriteService.GetAllForUserAsync(Session.Id).GetAwaiter().GetResult();

            Favorites = new ObservableCollection<Favorite>(favorites);
        }

        private bool CanGoBackward() => WebView.CanGoBack;

        private bool CanGoForward() => WebView.CanGoForward;

        private async Task DeleteFavoriteAsync(object id)
        {
            var favoriteId = (int)id;

            var context = Favorites.Where(x => x.Id == favoriteId).Select(x => x.Title).SingleOrDefault();

            var dialog = DialogHelper.GetContentDialog(DialogEnum.DeleteNoteDialog, context);
            var resoult = await dialog.ShowAsync();

            if (resoult == ContentDialogResult.Primary)
            {
                await _favoriteService.DeleteAsync(favoriteId);
                Favorites.Remove(Favorites.Where(x => x.Id == favoriteId).SingleOrDefault());
            }
        }

        private void InitializeWebView()
        {
            WebView = new WebView();
            WebView.NavigationStarting += WebView_NavigationStarting;
            WebView.NewWindowRequested += WebView_NewWindowRequested;
        }

        private void WebView_NavigationStarting(WebView sender, WebViewNavigationStartingEventArgs e) => Uri = e.Uri.AbsoluteUri;

        private void WebView_NewWindowRequested(WebView sender, WebViewNewWindowRequestedEventArgs e)
        {
            WebView.Navigate(e.Uri);
            e.Handled = true;
        }

        private void InitializeCommands()
        {
            GoBackwardCommand = new RelayCommand(() => WebView.GoBack(), CanGoBackward);
            GoForwardCommand = new RelayCommand(() => WebView.GoForward(), CanGoForward);
            GoToCommand = new RelayCommand(() => WebView.Navigate(new Uri(Uri)));
            RefreshCommand = new RelayCommand(() => WebView.Refresh());
            DeleteFavoriteCommand = new RelayCommand<object>(async x => await DeleteFavoriteAsync(x));
        }
    }
}