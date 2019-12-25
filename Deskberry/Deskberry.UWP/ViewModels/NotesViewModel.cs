﻿using Deskberry.Tools.Extensions.HelpModels;
using Deskberry.UWP.Commands;
using Deskberry.UWP.Services.Interfaces;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Windows.UI.Xaml.Controls;

namespace Deskberry.UWP.ViewModels
{
    public class NotesViewModel : INotifyPropertyChanged
    {
        public NoteMenuItem _selectedMenuItem;

        private INavigationService _navigationService;
        private INoteNavigationService _noteNavigationService;

        public NotesViewModel()
        {
        }

        public NotesViewModel(INavigationService navigationService, INoteNavigationService noteNavigationService)
        {
            _navigationService = navigationService;
            _noteNavigationService = noteNavigationService;

            NoteMenuItems = InitializeMenuItems();

            CloseSubAppCommand = new RelayCommand(() => CloseSubApp());
            NavigateBackCommand = new RelayCommand(() => NavigateBack());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public RelayCommand CloseSubAppCommand { get; private set; }
        public RelayCommand NavigateBackCommand { get; private set; }
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

        public void SetMenuItemOnStart()
        {
            SelectedMenuItem = NoteMenuItems.FirstOrDefault();
            _noteNavigationService.NavigateTo(SelectedMenuItem.Tag);
        }

        private void CloseSubApp()
        {
            _navigationService.ClearSubAppsWindow();
        }

        private ObservableCollection<NoteMenuItem> InitializeMenuItems()
        {
            var collection = new ObservableCollection<NoteMenuItem>
            {
                new NoteMenuItem { Name = "All notes", Tag = "AllNotesPage", Glyph = Symbol.List },
                new NoteMenuItem { Name = "Add note", Tag = "AddNotePage", Glyph = Symbol.Add }
            };

            return collection;
        }

        private void NavigateBack()
        {
            _navigationService.NavigateBackFromSubApp();
        }
    }
}