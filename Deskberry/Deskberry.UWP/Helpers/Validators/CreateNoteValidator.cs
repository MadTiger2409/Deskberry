using Deskberry.Tools.CommandObjects.Note;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deskberry.UWP.Helpers.Validators
{
    public class CreateNoteValidator : AbstractValidator<CreateNote>
    {
        public CreateNoteValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(300)
                .WithMessage("Title can't be empty and must be from 2 to 300 characters long");

            RuleFor(x => x.Description)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(500)
                .WithMessage("Description can't be empty and must be from 2 to 500 characters long");
        }
    }
}
