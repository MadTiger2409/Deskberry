using Deskberry.SQLite.Models;
using Deskberry.Tools.Extensions;
using Deskberry.Tools.Services.Interfaces;
using Deskberry.UWP.Commands;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Deskberry.UWP.ViewModels.Settings
{
    public class PersonalizationSettingsPageViewModel : INotifyPropertyChanged
    {
        private IAccountService _accountService;
        private IAvatarService _avatarService;
        private Account _currentAccount;
        private Avatar _selectedAvatar;

        public RelayCommand UpdateCommand { get; private set; }

        public Avatar SelectedAvatar
        {
            get => _selectedAvatar;
            set
            {
                if (value == _selectedAvatar)
                    return;

                _selectedAvatar = value;
                UpdateCommand.RaiseCanExecuteChanged();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedAvatar)));
            }
        }

        public ObservableCollection<Avatar> Avatars { get; set; }

        public async Task InitializeDataAsync()
        {
            _currentAccount = await _accountService.GetAsync(Session.Id);
            var avatars = await _avatarService.GetAsync();
            Avatars = new ObservableCollection<Avatar>(avatars);
            SelectedAvatar = Avatars.Where(x => x.Id == _currentAccount.AvatarId).FirstOrDefault();
        }

        public PersonalizationSettingsPageViewModel()
        {
        }

        public PersonalizationSettingsPageViewModel(IAvatarService avatarService, IAccountService accountService)
        {
            _avatarService = avatarService;
            _accountService = accountService;

            UpdateCommand = new RelayCommand(async () => await UpdateAvatarAsync(), CanUpdateAvatar);
        }

        private async Task UpdateAvatarAsync() => await _accountService.UpdateUserPictureAsync(_currentAccount, _selectedAvatar);

        private bool CanUpdateAvatar() => SelectedAvatar.Id != _currentAccount.AvatarId;

        public event PropertyChangedEventHandler PropertyChanged;
    }
}