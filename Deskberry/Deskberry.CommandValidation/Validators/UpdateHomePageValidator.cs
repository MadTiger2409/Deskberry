using Deskberry.CommandValidation.CommandObjects.HomePage;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deskberry.CommandValidation.Validators
{
    public class UpdateHomePageValidator : AbstractValidator<UpdateHomePage>
    {
        public UpdateHomePageValidator()
        {
            RuleFor(x => x.Uri)
                .NotEmpty()
                .Must(x => IncludeSpace(x) == false);
        }

        private Func<string, bool> IncludeSpace = (string value) =>
        {
            if (string.IsNullOrWhiteSpace(value))
                return true;

            return value.Contains(" ");
        };
    }
}