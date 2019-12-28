using Deskberry.SQLite.Models;
using Deskberry.Tools.Enums;
using Deskberry.Tools.Services.Interfaces;
using Deskberry.UWP.Commands;
using Deskberry.UWP.Commands.Generic;
using Deskberry.UWP.Helpers;
using System;
using System.Collections.Generic;
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

        public BrowserViewModel()
        {
        }

        public BrowserViewModel(IFavoriteService favoriteService)
        {
            _favoriteService = favoriteService;
            WebView = new WebView();
            Favorites = new ObservableCollection<Favorite>();

            GoBackwardCommand = new RelayCommand(() => WebView.GoBack(), CanGoBackward);
            GoForwardCommand = new RelayCommand(() => WebView.GoForward(), CanGoForward);
            RefreshCommand = new RelayCommand(() => WebView.Refresh());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public RelayCommand AddFavoriteCommand { get; protected set; }
        public RelayCommand<object> DeleteFavoriteCommand { get; protected set; }
        public ObservableCollection<Favorite> Favorites { get; set; }
        public RelayCommand GoBackwardCommand { get; protected set; }
        public RelayCommand GoForwardCommand { get; protected set; }
        public RelayCommand GoHomeCommand { get; protected set; }
        public RelayCommand RefreshCommand { get; protected set; }
        public WebView WebView { get; set; }

        public void RefreshFavoritesCollection()
        {
            // var favorites = _favoriteService.GetAllForUserAsync(Session.Id).GetAwaiter().GetResult();
            var favorites = new List<Favorite>
            {
                new Favorite("Google", @"https://google.com"),
                new Favorite("Google", @"https://google.com"),
                new Favorite("Google", @"https://google.com"),
                new Favorite("Google", @"https://google.com"),
                new Favorite("Google", @"https://google.com"),
                new Favorite("Google", @"https://google.com"),
                new Favorite("Google", @"https://google.com"),
                new Favorite("Google", @"https://google.com"),
                new Favorite("Google", @"https://google.com"),
                new Favorite("Google", @"https://google.com"),
                new Favorite("Google", @"https://google.com"),
                new Favorite("Google", @"https://google.com"),
                new Favorite("Google", @"https://google.com"),
                new Favorite("Google", @"https://google.com"),
                new Favorite("Google", @"https://google.com")
            };

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
    }
}