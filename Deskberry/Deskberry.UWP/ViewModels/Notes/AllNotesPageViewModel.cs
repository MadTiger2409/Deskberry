using Deskberry.SQLite.Models;
using Deskberry.Tools.CommandObjects.Note;
using Deskberry.Tools.Enums;
using Deskberry.Tools.Extensions;
using Deskberry.Tools.Services.Interfaces;
using Deskberry.UWP.Commands.Generic;
using Deskberry.UWP.Helpers;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace Deskberry.UWP.ViewModels.Notes
{
    public class AllNotesPageViewModel
    {
        private INoteService _noteService;

        public AllNotesPageViewModel()
        {
        }

        public AllNotesPageViewModel(INoteService noteService)
        {
            _noteService = noteService;

            InitializeCommands();

            Notes = new ObservableCollection<Note>();
        }

        public RelayCommand<object> DeleteCommand { get; protected set; }
        public RelayCommand<object> EditNoteCommand { get; protected set; }
        public ObservableCollection<Note> Notes { get; set; }

        public void RefreshNotesCollection()
        {
            var notes = _noteService.GetAllForUserAsync(Session.Id).GetAwaiter().GetResult();

            Notes = new ObservableCollection<Note>(notes);
        }

        private async Task DeleteNoteAsync(object id)
        {
            var noteId = (int)id;

            var context = Notes.Where(x => x.Id == noteId).Select(x => x.Title).SingleOrDefault();
            var dialog = DialogHelper.GetContentDialog(DialogEnum.DeleteNoteDialog, context);
            var resoult = await dialog.ShowAsync();

            if (resoult == ContentDialogResult.Primary)
            {
                await _noteService.DeleteAsync(noteId);
                Notes.Remove(Notes.Where(x => x.Id == noteId).SingleOrDefault());
            }
        }

        private async Task EditNoteAsync(object id)
        {
            var noteId = (int)id;

            var context = new UpdateNote(Notes.SingleOrDefault(x => x.Id == noteId));
            var dialog = DialogHelper.GetContentDialog(DialogEnum.EditNoteDialog, context);
            var result = await dialog.ShowAsync();

            if (result == ContentDialogResult.Primary)
            {
                context = (UpdateNote)dialog.DataContext;
                await _noteService.UpdateAsync(context);
            }
        }

        private void InitializeCommands()
        {
            DeleteCommand = new RelayCommand<object>(async x => await DeleteNoteAsync(x));
            EditNoteCommand = new RelayCommand<object>(async x => await EditNoteAsync(x));
        }
    }
}