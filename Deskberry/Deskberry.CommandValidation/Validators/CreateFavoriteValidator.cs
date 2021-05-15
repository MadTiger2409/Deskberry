using Deskberry.CommandValidation.CommandObjects.Favorite;
using FluentValidation;
using System;
using System.Linq.Expressions;

namespace Deskberry.CommandValidation.Validators
{
    public class CreateFavoriteValidator : AbstractValidator<CreateFavorite>
    {
        public CreateFavoriteValidator()
        {
            RuleSet("Title", () =>
            {
                RuleForTitle<string>(x => x.Title);
            });

            RuleSet("Uri", () =>
            {
                RuleForUri<string>(x => x.Uri);
            });

            RuleSet("Full", () =>
            {
                RuleForTitle<string>(x => x.Title);
                RuleForUri<string>(x => x.Uri);
            });
        }

        protected IRuleBuilderOptions<CreateFavorite, string> RuleForTitle<TProperty>(Expression<Func<CreateFavorite, string>> expression)
        {
            return RuleFor(expression)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(300);
        }

        protected IRuleBuilderOptions<CreateFavorite, string> RuleForUri<TProperty>(Expression<Func<CreateFavorite, string>> expression)
        {
            return RuleFor(expression)
                .NotEmpty()
                .MinimumLength(4)
                .MaximumLength(400);
        }
    }
}