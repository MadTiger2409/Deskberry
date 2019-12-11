﻿using Deskberry.Tools.CommandObjects.Note;
using Deskberry.Tools.Extensions;
using Deskberry.Tools.Services.Interfaces;
using Deskberry.UWP.Commands;
using Deskberry.UWP.Helpers.Validators;
using FluentValidation;
using System;
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
        private IValidator<CreateNote> _createNoteValidator;
        #endregion

        #region Commands
        public RelayCommand AddCommand { get; private set; }
        public RelayCommand ResetCommand { get; private set; }
        #endregion

        #region Properties
        public CreateNote NoteForm { get; set; }
        #endregion

        public AddNotePageViewModel() { }

        public AddNotePageViewModel(INoteService noteService, IAccountService accountService, IValidator<CreateNote> validator)
        {
            InitializeDependencies(noteService, accountService, validator);
            InitializeCommands();

            NoteForm = new CreateNote();
        }

        #region PrivateMethods
        private void InitializeDependencies(INoteService noteService, IAccountService accountService, IValidator<CreateNote> validator)
        {
            _noteService = noteService;
            _accountService = accountService;
            _createNoteValidator = validator;
        }

        private void InitializeCommands()
        {
            AddCommand = new RelayCommand(async () => await AddNoteAsync());
            ResetCommand = new RelayCommand(async () => await ResetNoteFormAsync());
        }

        private async Task AddNoteAsync()
        {
            var account = await _accountService.GetAsync(Session.Id);

            await _noteService.AddAsync(NoteForm, account);
            await ResetNoteFormAsync();
        }

        private async Task ResetNoteFormAsync()
        {
            await NoteForm.ClearAsync();
        }
        #endregion
    }
}
