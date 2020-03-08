using Deskberry.Tools.Services.Interfaces;

namespace Deskberry.UWP.ViewModels.Settings
{
    public class PersonalizationSettingsPageViewModel
    {
        private IAvatarService _avatarService;
        private IAccountService _accountService;

        public PersonalizationSettingsPageViewModel(IAvatarService avatarService, IAccountService accountService)
        {
            _avatarService = avatarService;
            _accountService = accountService;
        }
    }
}