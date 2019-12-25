using Deskberry.Tools.CommandObjects.Note;
using Deskberry.Tools.Extensions;
using Deskberry.Tools.Services.Interfaces;
using Deskberry.UWP.Commands;
using System.Threading.Tasks;

namespace Deskberry.UWP.ViewModels.Notes
{
    public class AddNotePageViewModel
    {
        private IAccountService _accountService;
        private INoteService _noteService;

        public AddNotePageViewModel()
        {
        }

        public AddNotePageViewModel(INoteService noteService, IAccountService accountService)
        {
            NoteForm = new CreateNote();

            InitializeDependencies(noteService, accountService);
            InitializeCommands();

            NoteForm.CanExecutedChanged = AddCommand.RaiseCanExecuteChanged;
        }

        public RelayCommand AddCommand { get; private set; }
        public CreateNote NoteForm { get; set; }
        public RelayCommand ResetCommand { get; private set; }

        private async Task AddNoteAsync()
        {
            var account = await _accountService.GetAsync(Session.Id);

            await _noteService.AddAsync(NoteForm, account);
            await ResetNoteFormAsync();
        }

        private void InitializeCommands()
        {
            AddCommand = new RelayCommand(async () => await AddNoteAsync(), NoteForm.IsValid);
            ResetCommand = new RelayCommand(async () => await ResetNoteFormAsync());
        }

        private void InitializeDependencies(INoteService noteService, IAccountService accountService)
        {
            _noteService = noteService;
            _accountService = accountService;
        }

        private async Task ResetNoteFormAsync() => await NoteForm.ClearAsync();
    }
}