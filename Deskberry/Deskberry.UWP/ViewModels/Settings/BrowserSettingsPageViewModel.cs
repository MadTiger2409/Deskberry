using Deskberry.Tools.CommandObjects.HomePage;
using Deskberry.Tools.Extensions;
using Deskberry.Tools.Services.Interfaces;
using Deskberry.UWP.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deskberry.UWP.ViewModels.Settings
{
    public class BrowserSettingsPageViewModel
    {
        private IAccountService _accountService;
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
                HomePageForm.Uri = (await _homePageService.GetAsync(Session.Id)).Uri;
            }
            catch (NullReferenceException)
            {
                HomePageForm.Uri = string.Empty;
            }
        }

        private async Task AddOrUpdateAsync()
        {
            var account = await _accountService.GetAsync(Session.Id);

            await _homePageService.AddOrUpdateAsync(account, HomePageForm);
        }

        private Task DeleteFavoritesAsync()
        {
            throw new NotImplementedException();
        }

        private void InitializeCommands()
        {
            SaveCommand = new RelayCommand(async () => await AddOrUpdateAsync(), HomePageForm.IsValid);
            DeleteCommand = new RelayCommand(async () => await DeleteFavoritesAsync());
        }

        private void InitializeDependencies(IHomePageService homePageService, IFavoriteService favoriteService, IAccountService accountService)
        {
            _homePageService = homePageService;
            _favoriteService = favoriteService;
            _accountService = accountService;
        }
    }
}