using Deskberry.Tools.CommandObjects.Note;
using FluentValidation;
using System;
using System.Linq.Expressions;

namespace Deskberry.Tools.Validators
{
    public class CreateNoteValidator : AbstractValidator<CreateNote>
    {
        public CreateNoteValidator()
        {
            RuleSet("Title", () =>
            {
                RuleForTitle<string>(x => x.Title);
            });

            RuleSet("Description", () =>
            {
                RuleForDescription<string>(x => x.Description);
            });

            RuleSet("Full", () =>
            {
                RuleForTitle<string>(x => x.Title);
                RuleForDescription<string>(x => x.Description);
            });
        }

        protected IRuleBuilderOptions<CreateNote, string> RuleForTitle<TProperty>(Expression<Func<CreateNote, string>> expression)
        {
            return RuleFor(expression)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(300)
                .WithMessage("Title can't be empty and must be from 2 to 300 characters long");
        }

        protected IRuleBuilderOptions<CreateNote, string> RuleForDescription<TProperty>(Expression<Func<CreateNote, string>> expression)
        {
            return RuleFor(expression)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(500)
                .WithMessage("Description can't be empty and must be from 2 to 500 characters long");
        }
    }
}
