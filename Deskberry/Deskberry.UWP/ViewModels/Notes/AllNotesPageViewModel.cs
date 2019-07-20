using Deskberry.SQLite.Models;
using Deskberry.Tools.Extensions;
using Deskberry.Tools.Services.Interfaces;
using Deskberry.Tools.Enums;
using Deskberry.UWP.Commands;
using Deskberry.UWP.Commands.Generic;
using Deskberry.UWP.Helpers;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using Windows.UI.Xaml.Controls;

namespace Deskberry.UWP.ViewModels.Notes
{
    public class AllNotesPageViewModel : INotifyPropertyChanged
    {
        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Injected
        private INoteService _noteService;
        #endregion

        #region Commands
        public RelayCommand<object> DeleteCommand { get; protected set; }
        public RelayCommand<object> EditNoteCommand { get; protected set; }
        #endregion

        #region Properties
        public ObservableCollection<Note> Notes { get; set; }
        #endregion

        public AllNotesPageViewModel() { }

        public AllNotesPageViewModel(INoteService noteService)
        {
            _noteService = noteService;

            InitializeCommands();

            Notes = new ObservableCollection<Note>();
        }

        #region PublicMethods
        public void RefreshNotesCollection()
        {
            var notes = _noteService.GetAllAsync(Session.Id).GetAwaiter().GetResult();
            Notes = new ObservableCollection<Note>(notes);
        }
        #endregion

        #region PrivateMethods
        private void InitializeCommands()
        {
            DeleteCommand = new RelayCommand<object>(async x => await DeleteNoteAsync(x));
            EditNoteCommand = new RelayCommand<object>(async x => await EditNoteAsync(x));
        }

        private async Task DeleteNoteAsync(object id)
        {
            var noteId = (int)id;

            await _noteService.DeleteAsync(noteId);
            RefreshNotesCollection();
        }

        private async Task EditNoteAsync(object id)
        {
            var noteId = (int)id;

            var note = Notes.SingleOrDefault(x => x.Id == noteId);
            var dialog = DialogHelper.GetContentDialog(DialogEnum.EditNoteDialog, note);
            await Task.FromResult(dialog.ShowAsync());
        }
        #endregion
    }
}
