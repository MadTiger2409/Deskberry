﻿using Deskberry.Tools.CommandObjects.Favorite;
using FluentValidation;
using System;
using System.Linq.Expressions;

namespace Deskberry.Tools.Validators
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
                .MaximumLength(300)
                .WithMessage("Title can't be empty and must be from 2 to 300 characters long");
        }

        protected IRuleBuilderOptions<CreateFavorite, string> RuleForUri<TProperty>(Expression<Func<CreateFavorite, string>> expression)
        {
            return RuleFor(expression)
                .NotEmpty()
                .MinimumLength(4)
                .MaximumLength(400)
                .WithMessage("Uri can't be empty and must be from 4 to 400 characters long");
        }
    }
}