using Deskberry.SQLite.Models;
using Deskberry.Tools.Extensions;
using Deskberry.Tools.Services.Interfaces;
using System.Collections.ObjectModel;
using System.ComponentModel;

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

        #region Properties
        public ObservableCollection<Note> Notes { get; set; }
        #endregion

        public AllNotesPageViewModel() { }

        public AllNotesPageViewModel(INoteService noteService)
        {
            _noteService = noteService;

            Notes = new ObservableCollection<Note>();
        }

        #region PublicMethods
        public void RefreshNotesCollection()
        {
            var notes = _noteService.GetAllAsync(Session.Id).GetAwaiter().GetResult();
            var notesCollection = new ObservableCollection<Note>(notes);
            Notes = notesCollection;
        }
        #endregion
    }
}
