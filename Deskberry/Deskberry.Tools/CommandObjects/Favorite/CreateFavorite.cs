using Deskberry.Tools.Validators;
using FluentValidation;
using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Deskberry.Tools.CommandObjects.Favorite
{
    public class CreateFavorite : INotifyPropertyChanged
    {
        protected bool _isTitleErrorVisible;
        protected bool _isUriErrorVisible;
        protected string _title;
        protected string _uri;

        private readonly CreateFavoriteValidator _validator;

        public CreateFavorite()
        {
            IsTitleErrorVisible = false;
            IsUriErrorVisible = false;
            _validator = new CreateFavoriteValidator();
        }

        public CreateFavorite(Action canExecutedCommand) : base() => CanExecutedChanged = canExecutedCommand;

        public event PropertyChangedEventHandler PropertyChanged;

        public Action CanExecutedChanged { get; set; }

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

        public bool IsUriErrorVisible
        {
            get { return _isUriErrorVisible; }
            set
            {
                if (value == _isUriErrorVisible)
                    return;

                _isUriErrorVisible = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsUriErrorVisible)));
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

        public string Uri
        {
            get { return _uri; }
            set
            {
                if (value == _uri)
                    return;

                _uri = value;

                IsUriErrorVisible = !_validator.Validate(this, ruleSet: "Uri").IsValid;
                CanExecutedChanged.Invoke();

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Uri)));
            }
        }

        public async Task ClearAsync()
        {
            await Task.FromResult(Title = null);
            await Task.FromResult(Uri = null);
            IsTitleErrorVisible = false;
            IsUriErrorVisible = false;
        }

        public bool IsValid() => _validator.Validate(this, ruleSet: "Full").IsValid;
    }
}