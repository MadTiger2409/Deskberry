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
        private readonly IFavoriteService _favoriteService;
        private readonly IHomePageService _homePageService;

        public BrowserSettingsPageViewModel(IHomePageService homePageService, IFavoriteService favoriteService)
        {
            _homePageService = homePageService;
            _favoriteService = favoriteService;
        }

        public RelayCommand DeleteCommand { get; set; }
        public RelayCommand SaveCommand { get; set; }

        public async Task InitializeDataAsync()
        {
            //TODO load home page there
        }
    }
}