using Deskberry.Tools.Validators;
using FluentValidation;
using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Deskberry.Tools.CommandObjects.Note
{
    public class CreateNote : INotifyPropertyChanged
    {
        protected string _description;
        protected bool _isDescriptionErrorVisible;
        protected bool _isTitleErrorVisible;
        protected string _title;

        private readonly CreateNoteValidator _validator;

        public CreateNote()
        {
            IsTitleErrorVisible = false;
            IsDescriptionErrorVisible = false;
            _validator = new CreateNoteValidator();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Action CanExecutedChanged { get; set; }

        public string Description
        {
            get { return _description; }
            set
            {
                if (value == _description)
                    return;

                _description = value;

                IsDescriptionErrorVisible = !_validator.Validate(this, ruleSet: "Description").IsValid;
                CanExecutedChanged.Invoke();

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Description)));
            }
        }

        public bool IsDescriptionErrorVisible
        {
            get { return _isDescriptionErrorVisible; }
            set
            {
                if (value == _isDescriptionErrorVisible)
                    return;

                _isDescriptionErrorVisible = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsDescriptionErrorVisible)));
            }
        }

        public bool IsTitleErrorVisible
        {
            get { return _isTitleErrorVisible; }
            set
            {
                if (value == _isTitleErrorVisible)
                    return;

                _isTitleErrorVisible = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsTitleErrorVisible)));
            }
        }

        public string Title
        {
            get { return _title; }
            set
            {
                if (value == _title)
                    return;

                _title = value;

                IsTitleErrorVisible = !_validator.Validate(this, ruleSet: "Title").IsValid;
                CanExecutedChanged.Invoke();

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Title)));
            }
        }

        public async Task ClearAsync()
        {
            await Task.FromResult(Title = null);
            await Task.FromResult(Description = null);
            IsTitleErrorVisible = false;
            IsDescriptionErrorVisible = false;
        }

        public bool IsValid() => _validator.Validate(this, ruleSet: "Full").IsValid;
    }
}