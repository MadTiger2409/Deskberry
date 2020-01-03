using Deskberry.SQLite.Models;
using Deskberry.Tools.CommandObjects.Favorite;
using Deskberry.Tools.Enums;
using Deskberry.Tools.Extensions;
using Deskberry.Tools.Services.Interfaces;
using Deskberry.UWP.Commands;
using Deskberry.UWP.Commands.Generic;
using Deskberry.UWP.Helpers;
using Deskberry.UWP.Services.Interfaces;
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
        private readonly INavigationService _navigationService;
        private readonly IAccountService _accountService;

        private string _title;
        private string _uri;

        public BrowserViewModel()
        {
        }

        public BrowserViewModel(IFavoriteService favoriteService, INavigationService navigationService, IAccountService accountService)
        {
            _favoriteService = favoriteService;
            _navigationService = navigationService;
            _accountService = accountService;
            FavoriteForm = new CreateFavorite();
            Favorites = new ObservableCollection<Favorite>();

            InitializeWebView();
            InitializeCommands();

            FavoriteForm.CanExecutedChanged = AddFavoriteCommand.RaiseCanExecuteChanged;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public RelayCommand AddFavoriteCommand { get; protected set; }
        public RelayCommand CloseSubAppCommand { get; protected set; }
        public RelayCommand<object> DeleteFavoriteCommand { get; protected set; }
        public CreateFavorite FavoriteForm { get; set; }
        public ObservableCollection<Favorite> Favorites { get; set; }
        public RelayCommand GoBackwardCommand { get; protected set; }
        public RelayCommand GoForwardCommand { get; protected set; }
        public RelayCommand GoHomeCommand { get; protected set; }
        public RelayCommand GoToCommand { get; protected set; }
        public RelayCommand NavigateBackCommand { get; private set; }
        public RelayCommand RefreshCommand { get; protected set; }

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Title)));
            }
        }

        public string Uri
        {
            get { return _uri; }
            set
            {
                _uri = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Uri)));
                GoToCommand.RaiseCanExecuteChanged();
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

        private bool CanGoTo() => !string.IsNullOrWhiteSpace(Uri);

        private void CloseSubApp() => _navigationService.ClearSubAppsWindow();

        private async Task DeleteFavoriteAsync(object id)
        {
            var favoriteId = (int)id;

            var context = Favorites.Where(x => x.Id == favoriteId).Select(x => x.Title).SingleOrDefault();

            var dialog = DialogHelper.GetContentDialog(DialogEnum.DeleteFavoriteDialog, context);
            var resoult = await dialog.ShowAsync();

            if (resoult == ContentDialogResult.Primary)
            {
                await _favoriteService.DeleteAsync(favoriteId);
                Favorites.Remove(Favorites.Where(x => x.Id == favoriteId).SingleOrDefault());
            }
        }

        private void GoTo()
        {
            var uriBuildder = new UriBuilder(Uri);
            WebView.Navigate(uriBuildder.Uri);
        }

        private void InitializeCommands()
        {
            AddFavoriteCommand = new RelayCommand(async () => await AddFavoriteAsync(), FavoriteForm.IsValid);
            GoBackwardCommand = new RelayCommand(() => WebView.GoBack(), CanGoBackward);
            GoForwardCommand = new RelayCommand(() => WebView.GoForward(), CanGoForward);
            GoToCommand = new RelayCommand(() => GoTo(), CanGoTo);
            RefreshCommand = new RelayCommand(() => WebView.Refresh());
            DeleteFavoriteCommand = new RelayCommand<object>(async x => await DeleteFavoriteAsync(x));
            CloseSubAppCommand = new RelayCommand(() => CloseSubApp());
            NavigateBackCommand = new RelayCommand(() => NavigateBack());
        }

        private void InitializeWebView()
        {
            WebView = new WebView();
            WebView.NavigationStarting += WebView_OnNavigationStarting;
            WebView.NewWindowRequested += WebView_OnNewWindowRequested;
            WebView.NavigationCompleted += WebView_OnNavigationCompleted;
        }

        private void NavigateBack() => _navigationService.NavigateBackFromSubApp();

        private async void WebView_OnNavigationCompleted(WebView sender, WebViewNavigationCompletedEventArgs e)
        {
            if (!e.IsSuccess)
            {
                var dialog = DialogHelper.GetContentDialog(DialogEnum.StandardDialog, $"{e.Uri.AbsoluteUri} is not a valid address or the server is unreachable.");
                await dialog.ShowAsync();
            }
            else
            {
                FavoriteForm.Title = Title = WebView.DocumentTitle;
                FavoriteForm.Uri = Uri;
            }
        }

        private void WebView_OnNavigationStarting(WebView sender, WebViewNavigationStartingEventArgs e)
        {
            Uri = e.Uri.AbsoluteUri;

            GoForwardCommand.RaiseCanExecuteChanged();
            GoBackwardCommand.RaiseCanExecuteChanged();
        }

        private void WebView_OnNewWindowRequested(WebView sender, WebViewNewWindowRequestedEventArgs e)
        {
            WebView.Navigate(e.Uri);
            e.Handled = true;
        }

        private async Task AddFavoriteAsync()
        {
            var account = await _accountService.GetAsync(Session.Id);

            var favorite = await _favoriteService.AddAsync(FavoriteForm, account);
            Favorites.Add(favorite);
        }
    }
}