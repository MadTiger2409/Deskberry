using Deskberry.CommandValidation.CommandObjects.Account;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Deskberry.CommandValidation.Validators
{
    public class CreateAccountValidator : AbstractValidator<CreateAccount>
    {
        public CreateAccountValidator()
        {
            RuleSet("Login", () =>
            {
                RuleForLogin<string>(x => x.Login);
            });

            RuleSet("Password", () =>
            {
                RuleForPassword<string>(x => x.Password);
            });

            RuleSet("Full", () =>
            {
                RuleForLogin<string>(x => x.Login);
                RuleForPassword<string>(x => x.Password);
            });
        }

        protected IRuleBuilderOptions<CreateAccount, string> RuleForLogin<TProperty>(Expression<Func<CreateAccount, string>> expression)
        {
            return RuleFor(expression)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(40);
        }

        protected IRuleBuilderOptions<CreateAccount, string> RuleForPassword<TProperty>(Expression<Func<CreateAccount, string>> expression)
        {
            return RuleFor(expression)
                .NotEmpty();
        }
    }
}