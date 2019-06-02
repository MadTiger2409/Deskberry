using Deskberry.Tools.Extensions.HelpModels;
using Deskberry.UWP.Commands;
using Deskberry.UWP.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace Deskberry.UWP.ViewModels
{
    public class NotesViewModel : INotifyPropertyChanged
    {
        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Fields
        public NoteMenuItem _selectedMenuItem;
        #endregion

        #region Injected
        private INavigationService _navigationService;
        private INoteNavigationService _noteNavigationService;
        #endregion

        #region Commands
        public RelayCommand CloseSubAppCommand { get; private set; }
        public RelayCommand NavigateBackCommand { get; private set; }
        #endregion

        #region Properties
        public ObservableCollection<NoteMenuItem> NoteMenuItems { get; set; }

        public NoteMenuItem SelectedMenuItem
        {
            get { return _selectedMenuItem; }
            set
            {
                if (value == _selectedMenuItem)
                    return;

                _selectedMenuItem = value;
                _noteNavigationService.NavigateTo(_selectedMenuItem.Tag);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedMenuItem)));
            }
        }

        #endregion

        public NotesViewModel() { }

        public NotesViewModel(INavigationService navigationService, INoteNavigationService noteNavigationService)
        {
            _navigationService = navigationService;
            _noteNavigationService = noteNavigationService;

            NoteMenuItems = InitializeMenuItems();

            // Write a public method to initialize SelectedMenuItem
            // and call it from OnNavigationTo event in NotesPage code behind

            CloseSubAppCommand = new RelayCommand(() => CloseSubApp());
            NavigateBackCommand = new RelayCommand(() => NavigateBack());
        }

        #region PrivateMethods
        private ObservableCollection<NoteMenuItem> InitializeMenuItems()
        {
            var collection = new ObservableCollection<NoteMenuItem>
            {
                new NoteMenuItem { Name = "All notes", Tag = "AllNotesPage", Glyph = Symbol.List },
                new NoteMenuItem { Name = "Add note", Tag = "AddNotePage", Glyph = Symbol.Add }
            };

            return collection;
        }

        private void CloseSubApp()
        {
            _navigationService.ClearSubAppsWindow();
        }

        private void NavigateBack()
        {
            _navigationService.NavigateBackFromSubApp();
        }
        #endregion
    }
}
