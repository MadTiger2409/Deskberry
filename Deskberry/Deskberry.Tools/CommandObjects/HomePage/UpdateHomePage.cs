using Deskberry.Tools.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deskberry.Tools.CommandObjects.HomePage
{
    public class UpdateHomePage : INotifyPropertyChanged
    {
        private readonly UpdateHomePageValidator _validator;
        private bool _isUriErrorVisible;
        private string _uri;

        public UpdateHomePage()
        {
            _validator = new UpdateHomePageValidator();

            IsUriErrorVisible = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Action CanExecutedChanged { get; set; }

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

        public string Uri
        {
            get => _uri;
            set
            {
                if (value == _uri)
                    return;

                if (!string.IsNullOrWhiteSpace(value))
                {
                    var builder = new UriBuilder(value);
                    _uri = builder.Uri.AbsoluteUri;
                }
                else
                {
                    _uri = value;
                }

                IsUriErrorVisible = !_validator.Validate(this).IsValid;
                CanExecutedChanged.Invoke();

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Uri)));
            }
        }

        public async Task ClearAsync() => await Task.FromResult(IsUriErrorVisible = false);

        public bool IsValid() => _validator.Validate(this).IsValid;
    }
}