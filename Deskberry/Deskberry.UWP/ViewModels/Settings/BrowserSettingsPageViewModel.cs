using Deskberry.Common.Models;
using Deskberry.CommandValidation.CommandObjects.HomePage;
using Deskberry.Helpers;
using Deskberry.Services.Interfaces;
using Deskberry.Helpers.Commands;
using System;
using System.Threading.Tasks;

namespace Deskberry.UWP.ViewModels.Settings
{
    public class BrowserSettingsPageViewModel
    {
        private IAccountService _accountService;
        private Account _currentAccount;
        private IFavoriteService _favoriteService;
        private IHomePageService _homePageService;

        public BrowserSettingsPageViewModel()
        {
        }

        public BrowserSettingsPageViewModel(IHomePageService homePageService, IFavoriteService favoriteService, IAccountService accountService)
        {
            HomePageForm = new UpdateHomePage();

            InitializeDependencies(homePageService, favoriteService, accountService);
            InitializeCommands();

            HomePageForm.CanExecutedChanged = SaveCommand.RaiseCanExecuteChanged;
        }

        public RelayCommand DeleteCommand { get; set; }
        public UpdateHomePage HomePageForm { get; set; }
        public RelayCommand SaveCommand { get; set; }

        public async Task InitializeDataAsync()
        {
            try
            {
                HomePageForm.Uri = (await _homePageService.GetAsync(Session.Id).ConfigureAwait(true)).Uri;
            }
            catch (NullReferenceException)
            {
                HomePageForm.Uri = string.Empty;
            }

            _currentAccount = await _accountService.GetAsync(Session.Id).ConfigureAwait(true);
            DeleteCommand.RaiseCanExecuteChanged();
        }

        private async Task AddOrUpdateAsync() => await _homePageService.AddOrUpdateAsync(_currentAccount, HomePageForm).ConfigureAwait(true);

        private async Task DeleteFavoritesAsync()
        {
            await _favoriteService.DeletellAsync(_currentAccount).ConfigureAwait(true);

            DeleteCommand.RaiseCanExecuteChanged();
        }

        private bool CanDeleteUserFavorites()
        {
            try
            {
                return _currentAccount.Favorites.Count > 0;
            }
            catch (NullReferenceException)
            {
                return false;
            }
        }

        private void InitializeCommands()
        {
            SaveCommand = new RelayCommand(async () => await AddOrUpdateAsync().ConfigureAwait(true), HomePageForm.IsValid);
            DeleteCommand = new RelayCommand(async () => await DeleteFavoritesAsync().ConfigureAwait(true), CanDeleteUserFavorites);
        }

        private void InitializeDependencies(IHomePageService homePageService, IFavoriteService favoriteService, IAccountService accountService)
        {
            _homePageService = homePageService;
            _favoriteService = favoriteService;
            _accountService = accountService;
        }
    }
}