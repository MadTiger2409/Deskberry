using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Deskberry.Tools.Validators;

namespace Deskberry.Tools.CommandObjects.Note
{
    public class CreateNote : INotifyPropertyChanged
    {
        #region Fields
        protected bool _isTitleErrorVisible;
        protected bool _isDescriptionErrorVisible;
        protected bool _isValid;

        protected string _title;
        protected string _description;
        private readonly CreateNoteValidator _validator;
        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Properties

        public Action CanExecutedChanged { get; set; }

        public string Title
        {
            get { return _title; }
            set
            {
                if (value == _title)
                    return;

                _title = value;
                Validate();
                CanExecutedChanged.Invoke();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Title)));
            }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                if (value == _description)
                    return;

                _description = value;
                Validate();
                CanExecutedChanged.Invoke();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Description)));
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
        #endregion

        public CreateNote()
        {
            _isValid = false;
            IsTitleErrorVisible = false;
            IsDescriptionErrorVisible = false;
            _validator = new CreateNoteValidator();
        }

        public async Task ClearAsync()
        {
            await Task.FromResult(Title = null);
            await Task.FromResult(Description = null);
        }

        public bool IsValid() => _isValid;

        protected void Validate()
        {
            var result = _validator.Validate(this);
            _isValid = result.IsValid;

            IsTitleErrorVisible = false;
            IsDescriptionErrorVisible = false;


            foreach (var failure in result.Errors)
            {
                switch (failure.PropertyName)
                {
                    case "Title":
                        IsTitleErrorVisible = true;
                        break;

                    case "Description":
                        IsDescriptionErrorVisible = true;
                        break;
                }
            }
        } 
    }
}
