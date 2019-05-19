using Deskberry.Tools.CommandObjects.Note;
using Deskberry.Tools.Extensions;
using Deskberry.Tools.Services.Interfaces;
using Deskberry.UWP.Commands;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Deskberry.UWP.ViewModels.Notes
{
    public class AddNotePageViewModel : INotifyPropertyChanged
    {
        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Injected
        private INoteService _noteService;
        private IAccountService _accountService;
        #endregion

        #region Commands
        public RelayCommand AddCommand { get; private set; }
        public RelayCommand CancelCommand { get; private set; }
        #endregion

        #region Properties
        public CreateNote NoteForm { get; set; }
        #endregion

        public AddNotePageViewModel() { }

        public AddNotePageViewModel(INoteService noteService, IAccountService accountService)
        {
            _noteService = noteService;
            _accountService = accountService;

            NoteForm = new CreateNote();

            AddCommand = new RelayCommand(async () => await AddNoteAsync());
        }

        #region PrivateMethods
        private async Task AddNoteAsync()
        {
            var account = await _accountService.GetAsync(Session.Id);

            //TODO Need to remove this and implement converter
            NoteForm.Description = "";

            await _noteService.AddAsync(NoteForm, account);
        }
        #endregion
    }
}
