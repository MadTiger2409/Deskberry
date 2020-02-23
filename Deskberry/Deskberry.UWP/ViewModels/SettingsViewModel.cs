using Deskberry.Tools.Extensions.HelpModels;
using Deskberry.UWP.Commands;
using Deskberry.UWP.Services.Interfaces;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace Deskberry.UWP.ViewModels
{
    public class SettingsViewModel : INotifyPropertyChanged
    {
        public IconMenuItem _selectedMenuItem;

        private INavigationService _navigationService;
        private ISettingNavigationService _settingNavigationService;

        public SettingsViewModel()
        {
        }

        public SettingsViewModel(INavigationService navigationService, ISettingNavigationService settingNavigationService)
        {
            _navigationService = navigationService;
            _settingNavigationService = settingNavigationService;

            NoteMenuItems = InitializeMenuItems();

            CloseSubAppCommand = new RelayCommand(() => CloseSubApp());
            NavigateBackCommand = new RelayCommand(() => NavigateBack());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public RelayCommand CloseSubAppCommand { get; private set; }
        public RelayCommand NavigateBackCommand { get; private set; }
        public ObservableCollection<IconMenuItem> NoteMenuItems { get; set; }

        public IconMenuItem SelectedMenuItem
        {
            get { return _selectedMenuItem; }
            set
            {
                if (value == _selectedMenuItem)
                    return;

                _selectedMenuItem = value;
                _settingNavigationService.NavigateTo(_selectedMenuItem.Tag);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedMenuItem)));
            }
        }

        public void SetMenuItemOnStart()
        {
            SelectedMenuItem = NoteMenuItems.FirstOrDefault();
            _settingNavigationService.NavigateTo(SelectedMenuItem.Tag);
        }

        private void CloseSubApp() => _navigationService.ClearSubAppsWindow();

        private ObservableCollection<IconMenuItem> InitializeMenuItems()
        {
            return new ObservableCollection<IconMenuItem>
            {
                new IconMenuItem { Name = "Security", Tag = "PasswordSettingsPage", GlyphCode = "\xE72E" },
                new IconMenuItem { Name = "Personalization", Tag = "PersonalizationSettingsPage", GlyphCode = "\xE771" },
                new IconMenuItem { Name = "Browser", Tag = "PersonalizationSettingsPage", GlyphCode = "\xF6FA" }
            };
        }

        private void NavigateBack() => _navigationService.NavigateBackFromSubApp();
    }
}