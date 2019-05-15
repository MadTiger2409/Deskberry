using Deskberry.Tools.Services.Interfaces;
using Deskberry.UWP.Commands;
using System.ComponentModel;

namespace Deskberry.UWP.ViewModels.Notes
{
    public class AddNotePageViewModel : INotifyPropertyChanged
    {
        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Injected
        private INoteService _noteService;
        #endregion

        #region Commands
        public RelayCommand AddCommand { get; private set; }
        public RelayCommand CancelCommand { get; private set; }
        #endregion

        public AddNotePageViewModel() { }

        public AddNotePageViewModel(INoteService noteService)
        {
            _noteService = noteService;
        }
    }
}
